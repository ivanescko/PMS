namespace PMS.Server.DTOs.ProjectStatusDTO.Queries
{
    /// <summary>
    /// DTO элемента списка статуса проектов.
    /// </summary>
    public class GetProjectStatusItemResponse
    {
        /// <summary>
        /// Идентификатор статуса проекта.
        /// </summary>
        public int ProjectStatusID { get; set; }

        /// <summary>
        /// Наименование статуса проекта.
        /// </summary>
        public required string Title { get; set; }
    }
}
