namespace PMS.Server.DTOs.UserDTO.Commands
{
    /// <summary>
    /// DTO запроса создания пользователя.
    /// </summary>
    public class CreateUserRequest
    {
        /// <summary>
        /// Логин пользователя, используемый для входа в систему
        /// </summary>
        public required string Login { get; set; }

        /// <summary>
        /// Пароль пользователя, используемый для аутентификации
        /// </summary>
        public required string Password { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Флаг, указывающий активен ли аккаунт пользователя
        /// <para>true - аккаунт активен</para>
        /// <para>false - аккаунт деактивирован</para>
        /// </summary>
        public bool IsActive { get; set; }
    }
}
