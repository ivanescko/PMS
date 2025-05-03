namespace PMS.Server.DTOs.SpecialityDTO.Commands
{
    /// <summary>
    /// DTO запроса создания специальности.
    /// </summary>
    public class CreateSpecialityRequest
    {
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
