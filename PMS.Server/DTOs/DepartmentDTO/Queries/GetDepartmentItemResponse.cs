namespace PMS.Server.DTOs.DepartmentDTO.Queries
{
    /// <summary>
    /// DTO элемента списка отдела.
    /// </summary>
    public class GetDepartmentItemResponse
    {
        /// <summary>
        /// Идентификатор отдела.
        /// </summary>
        public int DepartmentID { get; set; }

        /// <summary>
        /// Наименование отдела.
        /// </summary>
        public required string Title { get; set; }
    }
}
