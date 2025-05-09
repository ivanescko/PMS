namespace PMS.Server.DTOs.WorkTeamRoleDTO.Commands
{
    /// <summary>
    /// DTO запроса создания ролей команд.
    /// </summary>
    public class CreateWorkTeamRoleRequest
    {
        /// <summary>
        /// Наименование ролей команд.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Описание ролей команд.
        /// </summary>
        public string? Description { get; set; }
    }
}
