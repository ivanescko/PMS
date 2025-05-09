namespace PMS.Server.DTOs.WorkTeamRoleDTO.Queries
{
    /// <summary>
    /// DTO данных статуса ролей.
    /// </summary>
    public class GetWorkTeamRoleResponse
    {
        /// <summary>
        /// Уникальный идентификатор статуса ролей.
        /// </summary>
        public int WorkTeamRoleID { get; set; }

        /// <summary>
        /// Наименование статуса ролей.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Описание статуса ролей.
        /// </summary>
        public string? Description { get; set; }
    }
}
