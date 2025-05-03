namespace PMS.Model.Entities
{
    /// <summary>
    /// Роль доступа пользователя
    /// </summary>
    public class UserAccessRole
    {
        /// <summary>
        /// Уникальный идентификатор связанной сущности <see cref="Entities.AccessRole"/>
        /// </summary>
        public int AccessRoleID { get; set; }

        /// <summary>
        /// Роль доступа
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "многие к одному" с сущностью <see cref="Entities.AccessRole"/>.
        /// </remarks>
        public virtual required AccessRole AccessRole { get; set; }

        /// <summary>
        /// Уникальный идентификатор связанной сущности <see cref="Entities.User"/>
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "многие к одному" с сущностью <see cref="Entities.User"/>.
        /// </remarks>
        public virtual required User User { get; set; }
    }
}
