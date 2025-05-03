using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.Model.Entities
{
    /// <summary>
    /// Модуль
    /// </summary>
    public class Module
    {
        /// <summary>
        /// Уникальный идентификатор модуля
        /// </summary>
        public int ModuleID { get; set; }

        /// <summary>
        /// Наименование модуля
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Коллекция прав ролей, свазнных с сущностью <see cref="Module"/>
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "один ко многим" с сущностью <see cref="ModuleAccessRole"/>.
        /// </remarks>
        public virtual ICollection<ModuleAccessRole> ModuleAccessRoles { get; set; } = new List<ModuleAccessRole>();
    }
}
