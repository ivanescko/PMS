namespace PMS.Server.DTOs.ProjectTaskStatusDTO.Queries
{
    /// <summary>
    /// DTO элемента списка статуса задач проектов.
    /// </summary>
    public class GetProjectTaskStatusItemResponse
    {
        /// <summary>
        /// Идентификатор статуса задач проекта.
        /// </summary>
        public int ProjectTaskStatusID { get; set; }

        /// <summary>
        /// Наименование статуса задач проекта.
        /// </summary>
        public required string Title { get; set; }
    }
}
