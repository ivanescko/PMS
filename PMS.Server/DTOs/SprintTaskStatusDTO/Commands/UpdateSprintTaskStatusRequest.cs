namespace PMS.Server.DTOs.SprintTaskStatusDTO.Commands
{
    /// <summary>
    /// DTO запроса обновления статуса спринта.
    /// </summary>
    public class UpdateSprintTaskStatusRequest
    {
        /// <summary>
        /// Наименование статуса спринта.
        /// </summary>
        public string? Title { get; set; }

        ///// <summary>
        ///// Описание статуса спринта.
        ///// </summary>
        //public string? Description { get; set; }
    }
}
