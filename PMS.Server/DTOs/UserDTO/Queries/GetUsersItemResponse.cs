namespace PMS.Server.DTOs.UserDTO.Queries
{
    /// <summary>
    /// DTO элемента списка пользователей.
    /// </summary>
    public class GetUsersItemResponse
    {
        /// <summary>
        /// Уникальный идентификатор пользователя
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public required string Name { get; set; }
    }
}
