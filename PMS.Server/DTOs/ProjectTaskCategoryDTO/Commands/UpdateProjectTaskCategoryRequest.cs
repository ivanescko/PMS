namespace PMS.Server.DTOs.ProjectTaskCategoryDTO.Commands
{
    /// <summary>
    /// DTO запроса обновления категории задач проекта.
    /// </summary>
    public class UpdateProjectTaskCategoryRequest
    {
        /// <summary>
        /// Наименование категории задач проекта.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Описание категории задач проекта.
        /// </summary>
        public string? Description { get; set; }
    }
}
