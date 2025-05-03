using Microsoft.EntityFrameworkCore;
using PMS.Model.Context;

namespace PMS.Server.Extensions
{
    /// <summary>
    /// Класс расширений для настройки инфраструктуры базы данных.
    /// </summary>
    public static class DatabaseExtension
    {
        /// <summary>
        /// Метод расширения для настройки и регистрации контекста базы данных в DI-контейнере.
        /// </summary>
        /// <param name="services">Коллекция сервисов для регистрации зависимостей.</param>
        /// <param name="configuration">Конфигурация приложения, содержащая строки подключения.</param>
        /// <returns>Коллекция сервисов с зарегистрированным контекстом базы данных.</returns>
        public static IServiceCollection AddDatabaseConfiguration(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<PmsDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
