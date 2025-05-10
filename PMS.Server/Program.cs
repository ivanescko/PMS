
using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.IdentityModel.Tokens;
using PMS.Server.Exceptions;
using PMS.Server.Extensions;
using PMS.Server.Middlewares;

namespace PMS.Server
{
    /// <summary>
    /// Главный класс приложения, содержащий точку входа и конфигурацию веб-сервиса.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Настраивает и запускает веб-приложение ASP.NET Core с REST API, используя следующие конфигурации:
    /// </para>
    /// <list type="bullet">
    /// <item><description>Принудительное использование JSON как единственного формата ответа API</description></item>
    /// <item><description>Автоматическое подключение Swagger в среде разработки</description></item>
    /// <item><description>Регистрация всех необходимых сервисов (база данных, репозитории, MediatR, AutoMapper)</description></item>
    /// </list>
    /// </remarks>
    public class Program
    {
        /// <summary>
        /// Точка входа в приложение.
        /// </summary>
        /// <param name="args">Массив аргументов, используемых при запуске приложения.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Настройка CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:3000")
                              .AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowCredentials(); // Если нужно разрешить куки/аутентификацию
                    });
            });

            // JWT-аутентификация
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
                    ValidateIssuerSigningKey = true
                };
            });
            
            // Авторизация
            builder.Services.AddAuthorization();


            // Основные сервисы
            builder.Services.AddControllers(options =>
            {
                // Удалнеие неиспользуемых форматов данных
                options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
                options.OutputFormatters.RemoveType<StreamOutputFormatter>();
                options.OutputFormatters.RemoveType<StringOutputFormatter>();

                // Подключение формата JSON
                var jsonFormatter = options.OutputFormatters.OfType<SystemTextJsonOutputFormatter>().First();
                options.OutputFormatters.Clear();
                options.OutputFormatters.Add(jsonFormatter);

                // Явное указание формата application/json
                options.Filters.Add(new ProducesAttribute("application/json"));
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Подключение сервисов
            builder.Services
                .AddCustomValidation()
                .AddDatabaseConfiguration(builder.Configuration)
                .AddRepositories()
                .AddMediatRConfiguration()
                .AddAutoMapperWithValidation(builder.Environment)
                .AddSwaggerDocumentation();

            // Отключение стандартных сообщений об ошибке
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressMapClientErrors = true;
                options.InvalidModelStateResponseFactory = context =>
                {
                    // Собираем ошибки из ModelState
                    var errors = context.ModelState
                        .Where(e => e.Value != null && e.Value.Errors.Count > 0)
                        .ToDictionary(
                            kvp => kvp.Key,
                            kvp => kvp.Value != null ? kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray() : []
                        );

                    // Бросаем кастомное исключение с ошибками валидации
                    throw new BadRequestException("Ошибка валидации", errors);
                };
            });

            // Построение приложения
            var app = builder.Build();

            // Конфигурация middleware
            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerDocumentation();
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseCors("AllowSpecificOrigin");

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.Run();
        }
    }
}
