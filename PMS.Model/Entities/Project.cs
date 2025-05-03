namespace PMS.Model.Entities
{
    /// <summary>
    /// Проект
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Уникальный идентификатор проекта
        /// </summary>
        public int ProjectID { get; set; }

        /// <summary>
        /// Наименование проекта
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Описание проекта
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Дата создания проекта
        /// </summary>
        public required DateOnly CreatedDate { get; set; }

        /// <summary>
        /// Плановая дата начала проекта
        /// </summary>
        public DateOnly? EstimatedStartDate { get; set; }

        /// <summary>
        /// Фактическая дата начала проекта
        /// </summary>
        public DateOnly? ActualStartDate { get; set; }

        /// <summary>
        /// Плановая дата окончания проекта
        /// </summary>
        public DateOnly? EstimatedEndDate { get; set; }

        /// <summary>
        /// Фактическая дата оконачния проекта
        /// </summary>
        public DateOnly? ActualEndDate { get; set; }

        /// <summary>
        /// Уникальный идентификатор связанной сущности <see cref="User"/>
        /// </summary>
        public int CreatedByUserID { get; set; }

        /// <summary>
        /// Пользователь, создавший проект
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "многие к одному" с сущностью <see cref="Entities.User"/>.
        /// </remarks>
        public virtual required User CreatedByUser { get; set; }

        /// <summary>
        /// Уникальный идентификатор связанной сущности <see cref="User"/>
        /// </summary>
        public required int ManagerID { get; set; }

        /// <summary>
        /// Менеджер проекта
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "многие к одному" с сущностью <see cref="Entities.User"/>.
        /// </remarks>
        public virtual required User Manager { get; set; }

        /// <summary>
        /// Уникальный идентификатор связанной сущности <see cref="Entities.ProjectStatus"/>
        /// </summary>
        public int ProjectStatusID { get; set; }

        /// <summary>
        /// Статус проекта
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "многие к одному" с сущностью <see cref="Entities.ProjectStatus"/>.
        /// </remarks>
        public virtual required ProjectStatus ProjectStatus { get; set; }

        /// <summary>
        /// Уникальный идентификатор связанной сущности <see cref="Entities.ProjectCategory"/>
        /// </summary>
        public int? ProjectCategoryID { get; set; }

        /// <summary>
        /// Категория проекта
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "многие к одному" с сущностью <see cref="Entities.ProjectCategory"/>.
        /// </remarks>
        public virtual ProjectCategory? ProjectCategory { get; set; }

        /// <summary>
        /// Рабочая группа
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "один к одному" с сущностью <see cref="Entities.WorkTeam"/>.
        /// </remarks>
        public WorkTeam? WorkTeam { get; set; }

        /// <summary>
        /// Список версий проекта
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "один ко многим" с сущностью <see cref="ProjectRelease"/>.
        /// </remarks>
        public virtual ICollection<ProjectRelease> ProjectReleases { get; set; } = new List<ProjectRelease>();

        /// <summary>
        /// Список спринтов проекта
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "один ко многим" с сущностью <see cref="Sprint"/>.
        /// </remarks>
        public virtual ICollection<Sprint> Sprints { get; set; } = new List<Sprint>();
    }
}
