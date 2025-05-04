namespace PMS.Server.DTOs.ProjectCategoryDTO.Commands
{
    /// <summary>
    /// DTO запроса обновления категории проекта.
    /// </summary>
    public class UpdateProjectCategoryRequest
    {
        /// <summary>
        /// Наименование категории проекта.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Описание категории проекта.
        /// </summary>
        public string? Description { get; set; }
    }
}
