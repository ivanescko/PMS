using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace PMS.Server.Extensions
{
    /// <summary>
    /// Класс расширений для настройки Swagger/OpenAPI документации.
    /// </summary>
    public static class SwaggerExtensions
    {
        /// <summary>
        /// Метод расширения для настройки и регистрации Swagger документации.
        /// </summary>
        /// <param name="services">Коллекция сервисов для регистрации зависимостей.</param>
        /// <returns>Коллекция сервисов с настроенным SwaggerGen.</returns>
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "PMS API",
                    Version = "v1",
                    Description = "API Documentation"
                });

                config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                config.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });

                // Включение XML-комментариев
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        /// <summary>
        /// Подключение middleware для работы Swagger UI.
        /// </summary>
        /// <param name="app">Builder конфигурации приложения.</param>
        /// <returns>Builder конфигурации приложения с подключенным Swagger UI.</returns>
        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PMS API V1");
                c.RoutePrefix = "api-docs";
            });

            return app;
        }
    }
}
