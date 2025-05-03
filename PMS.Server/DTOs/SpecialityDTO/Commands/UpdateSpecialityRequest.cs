namespace PMS.Server.DTOs.SpecialityDTO.Commands
{
    /// <summary>
    /// DTO запроса обновления специальности.
    /// </summary>
    public class UpdateSpecialityRequest
    {
        /// <summary>
        /// Наименование специальности.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Описание специальности.
        /// </summary>
        public string? Description { get; set; }
    }
}
