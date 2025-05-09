namespace PMS.Server.DTOs.ProjectTaskCategoryDTO.Queries
{
    /// <summary>
    /// DTO данных категории задач проекта.
    /// </summary>
    public class GetProjectTaskCategoryResponse
    {
        /// <summary>
        /// Уникальный идентификатор категории задач проекта.
        /// </summary>
        public int ProjectTaskCategoryID { get; set; }

        /// <summary>
        /// Наименование категории задач проекта.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Описание категории задач проекта.
        /// </summary>
        public string? Description { get; set; }
    }
}
