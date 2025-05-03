using Microsoft.EntityFrameworkCore;
using PMS.Model.Entities;

namespace PMS.Model.Context
{
    /// <summary>
    /// Контекст базы данных для приложения PMS.
    /// </summary>
    public class PmsDbContext : DbContext
    {        
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="PmsDbContext"/> с заданными параметрами.
        /// При создании контекста автоматически применяются миграции к базе данных.
        /// </summary>
        /// <param name="options">Опции конфигурации контекста.</param>
        public PmsDbContext(DbContextOptions<PmsDbContext> options)
             : base(options)
        {
            // TODO: Сделать проверку, чтобы миграции применялись, если их нет в БД
            // Автоматическое применение миграций
            //Database.Migrate();
        }

        /// <summary>
        /// Набор сущностей специальностей. [<see cref="Speciality"/>]
        /// </summary>
        public DbSet<Speciality> Specialities { get; set; }

        /// <summary>
        /// Набор сущностей департаментов. [<see cref="Department"/>]
        /// </summary>
        public DbSet<Department> Departments { get; set; }

        /// <summary>
        /// Набор сущностей сотрудников. [<see cref="Employee"/>]
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Набор сущностей пользователей. [<see cref="User"/>]
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Набор сущностей модулей. [<see cref="Module"/>]
        /// </summary>
        public DbSet<Module> Modules { get; set; }

        /// <summary>
        /// Набор сущностей ролей доступа. [<see cref="AccessRole"/>]
        /// </summary>
        public DbSet<AccessRole> AccessRoles { get; set; }

        /// <summary>
        /// Набор сущностей связей между модулями и ролями доступа. [<see cref="ModuleAccessRole"/>]
        /// </summary>
        public DbSet<ModuleAccessRole> ModuleAccessRoles { get; set; }

        /// <summary>
        /// Набор сущностей связей между пользователями и ролями доступа. [<see cref="UserAccessRole"/>]
        /// </summary>
        public DbSet<UserAccessRole> UserAccessRoles { get; set; }

        /// <summary>
        /// Набор сущностей ролей рабочих команд. [<see cref="WorkTeamRole"/>]
        /// </summary>
        public DbSet<WorkTeamRole> WorkTeamRoles { get; set; }

        /// <summary>
        /// Набор сущностей статусов рабочих команд. [<see cref="WorkTeamStatus"/>]
        /// </summary>
        public DbSet<WorkTeamStatus> WorkTeamStatuses { get; set; }

        /// <summary>
        /// Набор сущностей рабочих команд. [<see cref="WorkTeam"/>]
        /// </summary>
        public DbSet<WorkTeam> WorkTeams { get; set; }

        /// <summary>
        /// Набор сущностей связей пользователей и ролей в рабочих командах. [<see cref="WorkTeamRoleUser"/>]
        /// </summary>
        public DbSet<WorkTeamRoleUser> WorkTeamRoleUsers { get; set; }

        /// <summary>
        /// Набор сущностей статусов проектов. [<see cref="ProjectStatus"/>]
        /// </summary>
        public DbSet<ProjectStatus> ProjectStatuses { get; set; }

        /// <summary>
        /// Набор сущностей категорий проектов. [<see cref="ProjectCategory"/>]
        /// </summary>
        public DbSet<ProjectCategory> ProjectCategories { get; set; }

        /// <summary>
        /// Набор сущностей проектов. [<see cref="Project"/>]
        /// </summary>
        public DbSet<Project> Projects { get; set; }

        /// <summary>
        /// Набор сущностей релизов проектов. [<see cref="ProjectRelease"/>]
        /// </summary>
        public DbSet<ProjectRelease> ProjectReleases { get; set; }

        /// <summary>
        /// Набор сущностей статусов задач проекта. [<see cref="ProjectTaskStatus"/>]
        /// </summary>
        public DbSet<ProjectTaskStatus> ProjectTaskStatuses { get; set; }

        /// <summary>
        /// Набор сущностей категорий задач проекта. [<see cref="ProjectTaskCategory"/>]
        /// </summary>
        public DbSet<ProjectTaskCategory> ProjectTaskCategories { get; set; }

        /// <summary>
        /// Набор сущностей задач проекта. [<see cref="ProjectTask"/>]
        /// </summary>
        public DbSet<ProjectTask> ProjectTasks { get; set; }

        /// <summary>
        /// Набор сущностей статусов задач спринта. [<see cref="SprintTaskStatus"/>]
        /// </summary>
        public DbSet<SprintTaskStatus> SprintTaskStatuses { get; set; }

        /// <summary>
        /// Набор сущностей спринтов. [<see cref="Sprint"/>]
        /// </summary>
        public DbSet<Sprint> Sprints { get; set; }

        /// <summary>
        /// Набор сущностей задач спринта. [<see cref="SprintTask"/>]
        /// </summary>
        public DbSet<SprintTask> SprintTasks { get; set; }

        /// <summary>
        /// Переопределение метода для конфигурации модели.
        /// Автоматическое применение всех конфигураций сущностей, найденных в сборке.
        /// </summary>
        /// <param name="modelBuilder">Объект для построения модели.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Применение конфигурации всех сущностей из текущей сборки.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PmsDbContext).Assembly);
        }
    }
}
