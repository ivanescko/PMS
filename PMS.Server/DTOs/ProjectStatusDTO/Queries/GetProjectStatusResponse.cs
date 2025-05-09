namespace PMS.Server.DTOs.ProjectStatusDTO.Queries
{
    /// <summary>
    /// DTO данных статуса проекта.
    /// </summary>
    public class GetProjectStatusResponse
    {
        /// <summary>
        /// Уникальный идентификатор статуса проекта.
        /// </summary>
        public int ProjectStatusID { get; set; }

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
