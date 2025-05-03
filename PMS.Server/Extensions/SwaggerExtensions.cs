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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "PMS API",
                    Version = "v1",
                    Description = "API Documentation"
                });

                // Включение XML-комментариев
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
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
