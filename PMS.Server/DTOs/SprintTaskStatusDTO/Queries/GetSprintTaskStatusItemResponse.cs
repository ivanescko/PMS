namespace PMS.Server.DTOs.SprintTaskStatusDTO.Queries
{
    /// <summary>
    /// DTO элемента списка статуса задач спринта.
    /// </summary>
    public class GetSprintTaskStatusItemResponse
    {
        /// <summary>
        /// Идентификатор статуса задач спринта.
        /// </summary>
        public int SprintTaskStatusID { get; set; }

        /// <summary>
        /// Наименование статуса задач спринта.
        /// </summary>
        public required string Title { get; set; }
    }
}
