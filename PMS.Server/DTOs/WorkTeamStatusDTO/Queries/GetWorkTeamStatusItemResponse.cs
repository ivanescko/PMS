namespace PMS.Server.DTOs.WorkTeamStatusDTO.Queries
{
    /// <summary>
    /// DTO элемента списка статуса команд.
    /// </summary>
    public class GetWorkTeamStatusItemResponse
    {
        /// <summary>
        /// Идентификатор статуса команд.
        /// </summary>
        public int WorkTeamStatusID { get; set; }

        /// <summary>
        /// Наименование статуса команд.
        /// </summary>
        public required string Title { get; set; }
    }
}
