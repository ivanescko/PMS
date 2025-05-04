namespace PMS.Server.DTOs.DepartmentDTO.Commands
{
    /// <summary>
    /// DTO запроса обновления отдела.
    /// </summary>
    public class UpdateDepartmentRequest
    {
        /// <summary>
        /// Код отдела.
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Наименование отдела.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Описание отдела.
        /// </summary>
        public string? Description { get; set; }
    }
}
