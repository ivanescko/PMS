namespace PMS.Model.Entities
{
    /// <summary>
    /// Рабочая группа
    /// </summary>
    public class WorkTeam
    {
        /// <summary>
        /// Уникальный идентификатор рабочей группы
        /// </summary>
        public int WorkTeamID { get; set; }

        /// <summary>
        /// Наимменование рабочей группы
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Описание рабочей группы
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Дата создания рабочей группы
        /// </summary>
        public DateOnly CreatedDate { get; set; }

        /// <summary>
        /// Уникальный идентификатор связанной сущности <see cref="User"/>
        /// </summary>
        public int CreatedByUserID { get; set; }

        /// <summary>
        /// Пользователь, создавший рабочую группу
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "многие к одному" с сущностью <see cref="User"/>.
        /// </remarks>
        public virtual required User CreatedByUser { get; set; }

        /// <summary>
        /// Уникальный идентификатор связанной сущности <see cref="Entities.WorkTeamStatus"/>
        /// </summary>
        public int? WorkTeamStatusID { get; set; }

        /// <summary>
        /// Статус рабочей группы
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "многие к одному" с сущностью <see cref="Entities.WorkTeamStatus"/>.
        /// </remarks>
        public virtual WorkTeamStatus? WorkTeamStatus { get; set; }

        /// <summary>
        /// Уникальный идентификатор связанной сущности <see cref="Entities.Project"/>
        /// </summary>
        public int? ProjectID { get; set; }

        /// <summary>
        /// Проект
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "многие к одному" с сущностью <see cref="Entities.Project"/>.
        /// </remarks>
        public virtual Project? Project { get; set; }

        /// <summary>
        /// Список рабочих групп
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "один ко многим" с сущностью <see cref="WorkTeams"/>.
        /// </remarks>
        public virtual ICollection<WorkTeamRoleUser> WorkTeams { get; set; } = new List<WorkTeamRoleUser>();
    }
}
