namespace PMS.Server.DTOs.ProjectTaskCategoryDTO.Queries
{
    /// <summary>
    /// DTO элемента списка категорий задач проектов.
    /// </summary>
    public class GetProjectTaskCategoryItemResponse
    {
        /// <summary>
        /// Идентификатор категории задач проекта.
        /// </summary>
        public int ProjectTaskCategoryID { get; set; }

        /// <summary>
        /// Наименование категории задач проекта.
        /// </summary>
        public required string Title { get; set; }
    }
}
