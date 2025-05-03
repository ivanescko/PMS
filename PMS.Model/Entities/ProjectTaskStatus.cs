namespace PMS.Model.Entities
{
    /// <summary>
    /// Статус задачи
    /// </summary>
    public class ProjectTaskStatus
    {
        /// <summary>
        /// Уникальный идентификатор статуса задачи
        /// </summary>
        public int ProjectTaskStatusID { get; set; }

        /// <summary>
        /// Наименование статуса задачи
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Описание статуса задачи
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
