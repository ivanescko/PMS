namespace PMS.Server.DTOs.UserDTO.Queries
{
    /// <summary>
    /// DTO данных пользователя.
    /// </summary>
    public class GetUserResponse
    {
        /// <summary>
        /// Уникальный идентификатор пользователя
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public required string Login { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Дата и время последней авторизации пользователя в системе
        /// </summary>
        public DateTime? LastLoginDate { get; set; }

        /// <summary>
        /// Флаг, указывающий активен ли аккаунт пользователя
        /// <para>true - аккаунт активен</para>
        /// <para>false - аккаунт деактивирован</para>
        /// </summary>
        public bool IsActive { get; set; }
    }
}
