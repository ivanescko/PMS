using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.Model.Entities
{
    /// <summary>
    /// Доступ роли к модулю
    /// </summary>
    public class ModuleAccessRole
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
        /// Уникальный идентификатор связанной сущности <see cref="Entities.Module"/>
        /// </summary>
        public int ModuleID { get; set; }

        /// <summary>
        /// Модуль
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "многие к одному" с сущностью <see cref="Entities.Module"/>.
        /// </remarks>
        public virtual required Module Module { get; set; }

        /// <summary>
        /// Право на создание
        /// </summary>
        public required bool Create { get; set; }

        /// <summary>
        /// Право на чтение
        /// </summary>
        public required bool Read { get; set; }

        /// <summary>
        /// Право на обновление
        /// </summary>
        public required bool Update { get; set; }

        /// <summary>
        /// Право на удаление
        /// </summary>
        public required bool Delete { get; set; }
    }
}
