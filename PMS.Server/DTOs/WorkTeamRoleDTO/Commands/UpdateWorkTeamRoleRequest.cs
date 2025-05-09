namespace PMS.Server.DTOs.WorkTeamRoleDTO.Commands
{
    /// <summary>
    /// DTO запроса обновления ролей команд.
    /// </summary>
    public class UpdateWorkTeamRoleRequest
    {
        /// <summary>
        /// Наименование ролей команд.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Описание ролей команд.
        /// </summary>
        public string? Description { get; set; }
    }
}
