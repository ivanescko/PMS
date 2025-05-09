namespace PMS.Server.DTOs.WorkTeamRoleDTO.Queries
{
    /// <summary>
    /// DTO элемента списка статуса ролей.
    /// </summary>
    public class GetWorkTeamRoleItemResponse
    {
        /// <summary>
        /// Идентификатор статуса ролей.
        /// </summary>
        public int WorkTeamRoleID { get; set; }

        /// <summary>
        /// Наименование статуса ролей.
        /// </summary>
        public required string Title { get; set; }
    }
}
