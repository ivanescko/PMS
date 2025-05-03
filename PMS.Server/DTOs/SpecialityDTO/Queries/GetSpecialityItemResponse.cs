namespace PMS.Server.DTOs.SpecialityDTO.Queries
{
    /// <summary>
    /// DTO элемента списка специальностей.
    /// </summary>
    public class GetSpecialityItemResponse
    {
        /// <summary>
        /// Идентификатор специальности.
        /// </summary>
        public int SpecialityID { get; set; }

        /// <summary>
        /// Наименование специальности.
        /// </summary>
        public required string Title { get; set; }
    }
}
