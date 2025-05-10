using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace PMS.Server.Extensions
{
    /// <summary>
    /// Класс расширений для подключения валидации CQRS.
    /// </summary>
    /// <remarks>
    /// <para>Добавляет методы валидации в коллекцию сервисов.</para>
    /// <para>Подключает команды репозиториев к валидации.</para>
    /// </remarks>
    public static class ValidationExtension
    {
        /// <summary>
        /// Метод расширения для настройки и регистрации валидации CQRS в DI-контейнере.
        /// </summary>
        /// <param name="services">Коллекция сервисов для регистрации зависимостей.</param>
        /// <returns>Коллекция сервисов с подключенной валидацией CQRS.</returns>
        public static IServiceCollection AddCustomValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(Program).Assembly);

            // Для автоматической валидации моделей
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }
    }
}
