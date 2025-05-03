namespace PMS.Model.Entities
{
    /// <summary>
    /// Статус рабочей группы
    /// </summary>
    public class WorkTeamStatus
    {
        /// <summary>
        /// Уникальный идентификатор статуса рабочей группы
        /// </summary>
        public int WorkTeamStatusID { get; set; }

        /// <summary>
        /// Наименование статуса рабочей группы
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Описание статуса рабочей группы
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Список рабочих групп
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "один ко многим" с сущностью <see cref="WorkTeam"/>.
        /// </remarks>
        public virtual ICollection<WorkTeam> WorkTeams { get; set; } = new List<WorkTeam>();
    }
}
