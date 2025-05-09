namespace PMS.Server.DTOs.WorkTeamStatusDTO.Queries
{
    /// <summary>
    /// DTO данных статуса команд.
    /// </summary>
    public class GetWorkTeamStatusResponse
    {
        /// <summary>
        /// Уникальный идентификатор статуса команд.
        /// </summary>
        public int WorkTeamStatusID { get; set; }

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
