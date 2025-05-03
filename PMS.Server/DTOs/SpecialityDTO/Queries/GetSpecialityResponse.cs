namespace PMS.Server.DTOs.SpecialityDTO.Queries
{
    /// <summary>
    /// DTO данных специальности.
    /// </summary>
    public class GetSpecialityResponse
    {
        /// <summary>
        /// Уникальный идентификатор специальности.
        /// </summary>
        public int SpecialityID { get; set; }

        /// <summary>
        /// Наименование специальности.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Описание специальности.
        /// </summary>
        public string? Description { get; set; }
    }
}
