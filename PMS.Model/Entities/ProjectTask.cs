namespace PMS.Model.Entities
{
    /// <summary>
    /// Задача
    /// </summary>
    public class ProjectTask
    {
        /// <summary>
        /// Уникальный идентификатор задачи
        /// </summary>
        public int ProjectTaskID { get; set; }

        /// <summary>
        /// Наименование задачи
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Описание задачи
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Дата создания задачи
        /// </summary>
        public required DateOnly CreatedDate { get; set; }

        /// <summary>
        /// Дата начала работы над задачей
        /// </summary>
        public DateOnly? StartDate { get; set; }

        /// <summary>
        /// Дата окончания работы над задачей
        /// </summary>
        public DateOnly? EndDate { get; set; }

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
        public int? ResponsibleUserID { get; set; }

        /// <summary>
        /// Ответственный за задачу
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "многие к одному" с сущностью <see cref="Entities.User"/>.
        /// </remarks>
        public User? ResponsibleUser { get; set; }

        /// <summary>
        /// Уникальный идентификатор связанной сущности <see cref="User"/>
        /// </summary>
        public int? ExecutorUserID { get; set; }

        /// <summary>
        /// Исполнитель задачи
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "многие к одному" с сущностью <see cref="Entities.User"/>.
        /// </remarks>
        public User? ExecutorUser { get; set; }

        /// <summary>
        /// Уникальный идентификатор связанной сущности <see cref="Project"/>
        /// </summary>
        public required int ProjectReleaseID { get; set; }

        /// <summary>
        /// Версия проекта
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "многие к одному" с сущностью <see cref="Entities.ProjectRelease"/>.
        /// </remarks>
        public required ProjectRelease ProjectRelease { get; set; }

        /// <summary>
        /// Уникальный идентификатор связанной сущности <see cref="Entities.ProjectTaskStatus"/>
        /// </summary>
        public required int ProjectTaskStatusID { get; set; }

        /// <summary>
        /// Статус задачи
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "многие к одному" с сущностью <see cref="Entities.ProjectTaskStatus"/>.
        /// </remarks>
        public required ProjectTaskStatus ProjectTaskStatus { get; set; }

        /// <summary>
        /// Уникальный идентификатор связанной сущности <see cref="Entities.ProjectTaskCategory"/>
        /// </summary>
        public int? ProjectTaskCategoryID { get; set; }

        /// <summary>
        /// Категория задачи
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "многие к одному" с сущностью <see cref="Entities.ProjectTaskCategory"/>.
        /// </remarks>
        public ProjectTaskCategory? ProjectTaskCategory { get; set; }

        /// <summary>
        /// Уникальный идентификатор связанной сущности <see cref="ProjectTask"/>
        /// </summary>
        public int? ParentTaskID { get; set; }

        /// <summary>
        /// Родительская задча
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "многие к одному" с сущностью <see cref="ProjectTask"/>.
        /// </remarks>
        public ProjectTask? ParentTask { get; set; }

        /// <summary>
        /// Список подзадач
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "один ко многим" с сущностью <see cref="ProjectTask"/>.
        /// </remarks>
        public ICollection<ProjectTask> Subtasks { get; set; } = new List<ProjectTask>();
    }
}
