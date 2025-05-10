using System.Reflection;
using AutoMapper;

namespace PMS.Server.Extensions
{
    /// <summary>
    /// Класс расширений для настройки AutoMapper.
    /// </summary>
    public static class AutoMapperExtension
    {
        /// <summary>
        /// Метод расширения для регистрации AutoMapper.
        /// </summary>
        /// <param name="services">Коллекция сервисов для регистрации зависимостей.</param>
        /// <param name="environment">Среда выполнения приложения.</param>
        /// <returns>Коллекция сервисов с зарегистрированным экземпляром AutoMapper.</returns>
        public static IServiceCollection AddAutoMapperWithValidation(
            this IServiceCollection services,
            IHostEnvironment environment)
        {
            // Подключение всех профилей мапинга в сборке
            var config = new MapperConfiguration(config =>
            {
                config.AddMaps(Assembly.GetExecutingAssembly());
            });

            // Проверка валидности мапингов
            config.AssertConfigurationIsValid();

            // Предварительная компиляция мапингов для прода
            if (environment.IsProduction())
            {
                config.CompileMappings();
            }

            services.AddSingleton(config.CreateMapper());
            return services;
        }
    }
}
