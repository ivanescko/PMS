using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.Model.Entities
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        /// <summary>
        /// Уникальный идентификатор пользователя
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Логин пользователя, используемый для входа в систему
        /// </summary>
        public required string Login { get; set; }

        /// <summary>
        /// Пароль пользователя, используемый для аутентификации
        /// </summary>
        public required string Password { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Дата и время последней авторизации пользователя в системе
        /// </summary>
        public DateTime? LastLoginDate { get; set; }

        /// <summary>
        /// Флаг, указывающий активен ли аккаунт пользователя
        /// <para>true - аккаунт активен</para>
        /// <para>false - аккаунт деактивирован</para>
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "один к одному" с сущностью <see cref="Entities.Employee"/>.
        /// </remarks>
        public virtual Employee? Employee { get; set; }

        /// <summary>
        /// Список прав пользователя
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "один ко многим" с сущностью <see cref="UserAccessRole"/>.
        /// </remarks>
        public virtual ICollection<UserAccessRole> UserAccess { get; set; } = new List<UserAccessRole>();

        /// <summary>
        /// Список рабочих групп, в которых состоит пользователь
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "один ко многим" с сущностью <see cref="WorkTeamRoleUser"/>.
        /// </remarks>
        public virtual ICollection<WorkTeamRoleUser> WorkTeams { get; set; } = new List<WorkTeamRoleUser>();

        /// <summary>
        /// Список рабочих групп, созданных пользователем
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "один ко многим" с сущностью <see cref="WorkTeam"/>.
        /// </remarks>
        public virtual ICollection<WorkTeam> CreatedWorkTeams { get; set; } = new List<WorkTeam>();

        /// <summary>
        /// Список проектов, созданных пользователем
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "один ко многим" с сущностью <see cref="Project"/>.
        /// </remarks>
        public virtual ICollection<Project> CreatedProjects { get; set; } = new List<Project>();

        /// <summary>
        /// Список проектов, которыми управляет пользователь
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "один ко многим" с сущностью <see cref="Project"/>.
        /// </remarks>
        public virtual ICollection<Project> ManagedProjects { get; set; } = new List<Project>();

        /// <summary>
        /// Список задач, созданных пользователем
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "один ко многим" с сущностью <see cref="ProjectTask"/>.
        /// </remarks>
        public virtual ICollection<ProjectTask> CreatedProjectTasks { get; set; } = new List<ProjectTask>();

        /// <summary>
        /// Список задач, где пользователь отвественный
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "один ко многим" с сущностью <see cref="ProjectTask"/>.
        /// </remarks>
        public virtual ICollection<ProjectTask> ResponsibleForTasks { get; set; } = new List<ProjectTask>();

        /// <summary>
        /// Список задач, где пользователь исполнитель
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "один ко многим" с сущностью <see cref="ProjectTask"/>.
        /// </remarks>
        public virtual ICollection<ProjectTask> TasksExecutedBy { get; set; } = new List<ProjectTask>();
    }
}
