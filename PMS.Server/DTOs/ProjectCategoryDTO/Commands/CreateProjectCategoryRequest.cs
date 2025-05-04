namespace PMS.Server.DTOs.ProjectCategoryDTO.Commands
{
    /// <summary>
    /// DTO запроса создания категории проекта.
    /// </summary>
    public class CreateProjectCategoryRequest
    {
        /// <summary>
        /// Наименование категории проекта.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Описание категории проекта.
        /// </summary>
        public string? Description { get; set; }
    }
}
