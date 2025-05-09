namespace PMS.Server.DTOs.WorkTeamStatusDTO.Commands
{
    /// <summary>
    /// DTO запроса создания статуса команд.
    /// </summary>
    public class CreateWorkTeamStatusRequest
    {
        /// <summary>
        /// Наименование статуса команд.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Описание статуса команд.
        /// </summary>
        public string? Description { get; set; }
    }
}
