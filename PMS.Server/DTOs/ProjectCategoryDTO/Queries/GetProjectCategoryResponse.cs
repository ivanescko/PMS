namespace PMS.Server.DTOs.ProjectCategoryDTO.Queries
{
    /// <summary>
    /// DTO данных категории проекта.
    /// </summary>
    public class GetProjectCategoryResponse
    {
        /// <summary>
        /// Уникальный идентификатор категории проекта.
        /// </summary>
        public int ProjectCategoryID { get; set; }

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
