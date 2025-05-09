namespace PMS.Server.DTOs.SprintTaskStatusDTO.Queries
{
    /// <summary>
    /// DTO данных статуса задач спринта.
    /// </summary>
    public class GetSprintTaskStatusResponse
    {
        /// <summary>
        /// Уникальный идентификатор статуса задач спринта.
        /// </summary>
        public int SprintTaskStatusID { get; set; }

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
