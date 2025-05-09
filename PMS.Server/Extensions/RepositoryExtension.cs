using PMS.Server.Repositories.DepartmentRepository;
using PMS.Server.Repositories.ProjectCategoryRepository;
using PMS.Server.Repositories.ProjectStatusRepository;
using PMS.Server.Repositories.ProjectTaskCategoryRepository;
using PMS.Server.Repositories.SpecialityRepository;
using PMS.Server.Repositories.UserRepository;

namespace PMS.Server.Extensions
{
    /// <summary>
    /// Класс расширений для настройки репозиториев CQRS.
    /// </summary>
    public static class RepositoryExtension
    {
        /// <summary>
        /// Метод расширения для настройки и регистрации репозиториев CQRS в DI-контейнере.
        /// </summary>
        /// <param name="services">Коллекция сервисов для регистрации зависимостей.</param>
        /// <returns>Коллекция сервисов с зарегистрированными репозиториями CQRS.</returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISpecialityRepository, SpecialityRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IProjectCategoryRepository, ProjectCategoryRepository>();
            services.AddScoped<IProjectStatusRepository, ProjectStatusRepository>();
            services.AddScoped<IProjectTaskCategoryRepository, ProjectTaskCategoryRepository>();
            // TODO прочие репозитории добавляются здесь

            return services;
        }
    }
}
