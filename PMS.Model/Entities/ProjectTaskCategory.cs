namespace PMS.Model.Entities
{
    /// <summary>
    /// Категория задачи
    /// </summary>
    public class ProjectTaskCategory
    {
        /// <summary>
        /// Уникальный идентификатор категории задачи
        /// </summary>
        public int ProjectTaskCategoryID { get; set; }

        /// <summary>
        /// Наименование категории задачи
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Описание категории задачи
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Список задач
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "один ко многим" с сущностью <see cref="ProjectTask"/>
        /// </remarks>
        public ICollection<ProjectTask> ProjectTasks { get; set; } = new List<ProjectTask>();
    }
}
