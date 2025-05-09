namespace PMS.Server.DTOs.SprintTaskStatusDTO.Commands
{
    /// <summary>
    /// DTO запроса создания статуса задач спринта.
    /// </summary>
    public class CreateSprintTaskStatusRequest
    {
        /// <summary>
        /// Наименование статуса задач спринта.
        /// </summary>
        public required string Title { get; set; }

        ///// <summary>
        ///// Описание статуса задач спринта.
        ///// </summary>
        //public string? Description { get; set; }
    }
}
