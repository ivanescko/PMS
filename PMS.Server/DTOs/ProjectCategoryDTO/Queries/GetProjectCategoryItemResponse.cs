namespace PMS.Server.DTOs.ProjectCategoryDTO.Queries
{
    /// <summary>
    /// DTO элемента списка категорий проектов.
    /// </summary>
    public class GetProjectCategoryItemResponse
    {
        /// <summary>
        /// Идентификатор категории проекта.
        /// </summary>
        public int ProjectCategoryID { get; set; }

        /// <summary>
        /// Наименование категории проекта.
        /// </summary>
        public required string Title { get; set; }
    }
}
