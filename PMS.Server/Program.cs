
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
    /// ������� ����� ����������, ���������� ����� ����� � ������������ ���-�������.
    /// </summary>
    /// <remarks>
    /// <para>
    /// ����������� � ��������� ���-���������� ASP.NET Core � REST API, ��������� ��������� ������������:
    /// </para>
    /// <list type="bullet">
    /// <item><description>�������������� ������������� JSON ��� ������������� ������� ������ API</description></item>
    /// <item><description>�������������� ����������� Swagger � ����� ����������</description></item>
    /// <item><description>����������� ���� ����������� �������� (���� ������, �����������, MediatR, AutoMapper)</description></item>
    /// </list>
    /// </remarks>
    public class Program
    {
        /// <summary>
        /// ����� ����� � ����������.
        /// </summary>
        /// <param name="args">������ ����������, ������������ ��� ������� ����������.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ��������� CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:3000")
                              .AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowCredentials(); // ���� ����� ��������� ����/��������������
                    });
            });

            // JWT-��������������
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
            
            // �����������
            builder.Services.AddAuthorization();


            // �������� �������
            builder.Services.AddControllers(options =>
            {
                // �������� �������������� �������� ������
                options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
                options.OutputFormatters.RemoveType<StreamOutputFormatter>();
                options.OutputFormatters.RemoveType<StringOutputFormatter>();

                // ����������� ������� JSON
                var jsonFormatter = options.OutputFormatters.OfType<SystemTextJsonOutputFormatter>().First();
                options.OutputFormatters.Clear();
                options.OutputFormatters.Add(jsonFormatter);

                // ����� �������� ������� application/json
                options.Filters.Add(new ProducesAttribute("application/json"));
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // ����������� ��������
            builder.Services
                .AddCustomValidation()
                .AddDatabaseConfiguration(builder.Configuration)
                .AddRepositories()
                .AddMediatRConfiguration()
                .AddAutoMapperWithValidation(builder.Environment)
                .AddSwaggerDocumentation();

            // ���������� ����������� ��������� �� ������
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressMapClientErrors = true;
                options.InvalidModelStateResponseFactory = context =>
                {
                    // �������� ������ �� ModelState
                    var errors = context.ModelState
                        .Where(e => e.Value != null && e.Value.Errors.Count > 0)
                        .ToDictionary(
                            kvp => kvp.Key,
                            kvp => kvp.Value != null ? kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray() : []
                        );

                    // ������� ��������� ���������� � �������� ���������
                    throw new BadRequestException("������ ���������", errors);
                };
            });

            // ���������� ����������
            var app = builder.Build();

            // ������������ middleware
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
