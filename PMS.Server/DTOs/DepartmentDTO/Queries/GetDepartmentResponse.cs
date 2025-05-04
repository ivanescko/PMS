namespace PMS.Server.DTOs.DepartmentDTO.Queries
{
    /// <summary>
    /// DTO данных отдела.
    /// </summary>
    public class GetDepartmentResponse
    {
        /// <summary>
        /// Уникальный идентификатор отдела.
        /// </summary>
        public int DepartmentID { get; set; }

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
