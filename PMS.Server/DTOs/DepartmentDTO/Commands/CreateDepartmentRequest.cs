namespace PMS.Server.DTOs.DepartmentDTO.Commands
{
    /// <summary>
    /// DTO запроса создания отдела.
    /// </summary>
    public class CreateDepartmentRequest
    {
        /// <summary>
        /// Код отдела.
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Наименование отдела.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Описание отдела.
        /// </summary>
        public string? Description { get; set; }
    }
}
