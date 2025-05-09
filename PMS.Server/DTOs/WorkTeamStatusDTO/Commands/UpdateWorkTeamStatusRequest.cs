namespace PMS.Server.DTOs.WorkTeamStatusDTO.Commands
{
    /// <summary>
    /// DTO запроса обновления статуса команд.
    /// </summary>
    public class UpdateWorkTeamStatusRequest
    {
        /// <summary>
        /// Наименование статуса команд.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Описание статуса команд.
        /// </summary>
        public string? Description { get; set; }
    }
}
