namespace PMS.Server.DTOs.UserDTO.Commands
{
    /// <summary>
    /// DTO запроса обновления пользователя.
    /// </summary>
    public class UpdateUserRequest
    {
        /// <summary>
        /// Логин пользователя, используемый для входа в систему
        /// </summary>
        public string? Login { get; set; }

        /// <summary>
        /// Пароль пользователя, используемый для аутентификации
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Флаг, указывающий активен ли аккаунт пользователя
        /// <para>true - аккаунт активен</para>
        /// <para>false - аккаунт деактивирован</para>
        /// </summary>
        public bool? IsActive { get; set; }
    }
}
