namespace PMS.Server.DTOs.ProjectStatusDTO.Commands
{
    /// <summary>
    /// DTO запроса создания статуса проекта.
    /// </summary>
    public class CreateProjectStatusRequest
    {
        /// <summary>
        /// Наименование статуса проекта.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Описание статуса проекта.
        /// </summary>
        public string? Description { get; set; }
    }
}
