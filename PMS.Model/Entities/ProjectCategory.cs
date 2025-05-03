namespace PMS.Model.Entities
{
    /// <summary>
    /// Категория проекта
    /// </summary>
    public class ProjectCategory
    {
        /// <summary>
        /// Уникальный идентификатор категории проекта
        /// </summary>
        public int ProjectCategoryID { get; set; }

        /// <summary>
        /// Наименование категории проекта
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Описание категории проекта
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
