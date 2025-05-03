using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.Model.Entities
{
    /// <summary>
    /// Роль доступа
    /// </summary>
    public class AccessRole
    {
        /// <summary>
        /// Уникальный идентификатор роли доступа
        /// </summary>
        public int AccessRoleID { get; set; }

        /// <summary>
        /// Наименование роли доступа
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Флаг, указывающий, активна ли роль доступа
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Коллекция прав ролей, свазнных с сущностью <see cref="AccessRole"/>
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "один ко многим" с сущностью <see cref="ModuleAccessRole"/>.
        /// </remarks>
        public virtual ICollection<ModuleAccessRole> ModuleAccessRoles { get; set; } = new List<ModuleAccessRole>();

        /// <summary>
        /// Коллекция прав пользователей, свазнных с сущностью <see cref="AccessRole"/>
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "один ко многим" с сущностью <see cref="UserAccessRole"/>.
        /// </remarks>
        public virtual ICollection<UserAccessRole> UserAccessRoles { get; set; } = new List<UserAccessRole>();
    }
}
