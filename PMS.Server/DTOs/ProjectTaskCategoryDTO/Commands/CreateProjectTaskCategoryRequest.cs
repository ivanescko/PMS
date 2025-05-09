namespace PMS.Server.DTOs.ProjectTaskCategoryDTO.Commands
{
    /// <summary>
    /// DTO запроса создания категории задач проекта.
    /// </summary>
    public class CreateProjectTaskCategoryRequest
    {
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
