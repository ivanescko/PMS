namespace PMS.Server.DTOs.ProjectTaskStatusDTO.Commands
{
    /// <summary>
    /// DTO запроса создания статуса задач проекта.
    /// </summary>
    public class CreateProjectTaskStatusRequest
    {
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
