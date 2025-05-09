namespace PMS.Server.DTOs.ProjectTaskStatusDTO.Queries
{
    /// <summary>
    /// DTO данных статуса задач проекта.
    /// </summary>
    public class GetProjectTaskStatusResponse
    {
        /// <summary>
        /// Уникальный идентификатор статуса задач проекта.
        /// </summary>
        public int ProjectTaskStatusID { get; set; }

        /// <summary>
        /// Наименование статуса задач проекта.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Описание статуса задач проекта.
        /// </summary>
        public string? Description { get; set; }
    }
}
