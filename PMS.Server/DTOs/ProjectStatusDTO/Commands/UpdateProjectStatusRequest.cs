namespace PMS.Server.DTOs.ProjectStatusDTO.Commands
{
    /// <summary>
    /// DTO запроса обновления статуса проекта.
    /// </summary>
    public class UpdateProjectStatusRequest
    {
        /// <summary>
        /// Наименование статуса проекта.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Описание статуса проекта.
        /// </summary>
        public string? Description { get; set; }
    }
}
