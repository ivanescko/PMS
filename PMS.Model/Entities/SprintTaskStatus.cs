namespace PMS.Model.Entities
{
    /// <summary>
    /// Статус задачи спринта
    /// </summary>
    public class SprintTaskStatus
    {
        /// <summary>
        /// Уникальный идентификатор статуса задачи спринта
        /// </summary>
        public int SprintTaskStatusID { get; set; }

        /// <summary>
        /// Наименование статуса задачи спринта
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Список задача спринта
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "один ко многим" с сущностью <see cref="SprintTask"/>.
        /// </remarks>
        public virtual ICollection<SprintTask> SprintTasks { get; set; } = new List<SprintTask>();
    }
}
