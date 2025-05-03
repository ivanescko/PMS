namespace PMS.Model.Entities
{
    /// <summary>
    /// Роль пользователя в рабочей группе
    /// </summary>
    public class WorkTeamRole
    {
        /// <summary>
        /// Уникальный идентификатор роли
        /// </summary>
        public int WorkTeamRoleID { get; set; }

        /// <summary>
        /// Наименование роли
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Описание роли
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Список рабочих групп
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "один ко многим" с сущностью <see cref="WorkTeamRoleUser"/>.
        /// </remarks>
        public virtual ICollection<WorkTeamRoleUser> WorkTeams { get; set; } = new List<WorkTeamRoleUser>();
    }
}
