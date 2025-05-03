namespace PMS.Server.Extensions
{
    /// <summary>
    /// Класс расширений для настройки MediatR.
    /// </summary>
    public static class MediatRExtension
    {
        /// <summary>
        /// Метод расширения для регистрации MediatR.
        /// </summary>
        /// <param name="services">Коллекция сервисов для регистрации зависимостей.</param>
        /// <returns>Коллекция сервисов с зарегистрированным экземпляром MediatR.</returns>
        public static IServiceCollection AddMediatRConfiguration(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

            return services;
        }
    }
}
