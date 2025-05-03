namespace PMS.Model.Entities
{
    /// <summary>
    /// Статус проекта
    /// </summary>
    public class ProjectStatus
    {
        /// <summary>
        /// Уникальный идентификатор статуса проекта
        /// </summary>
        public int ProjectStatusID { get; set; }

        /// <summary>
        /// Наименование статуса проекта
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Описание статуса проекта
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Список проектов
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "один ко многим" с сущностью <see cref="Project"/>.
        /// </remarks>
        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
