namespace PMS.Model.Entities
{
    /// <summary>
    /// Сущность связывающая рабочую группу, пользователя и роль
    /// </summary>
    /// <remarks>
    /// Рабочая группа <see cref="Entities.WorkTeam"/>.
    /// Пользователь <see cref="Entities.User"/>.
    /// Роль <see cref="Entities.WorkTeamRole"/>.
    /// </remarks>
    public class WorkTeamRoleUser
    {
        /// <summary>
        /// Уникальный идентификатор связанной сущности <see cref="Entities.WorkTeam"/>
        /// </summary>
        public int WorkTeamID { get; set; }

        /// <summary>
        /// Рабочая группа
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "многие к одному" с сущностью <see cref="Entities.WorkTeam"/>.
        /// </remarks>
        public virtual required WorkTeam WorkTeam { get; set; }

        /// <summary>
        /// Уникальный идентификатор связанной сущности <see cref="Entities.User"/>
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Пользователь, состоящий в рабочей группе
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "многие к одному" с сущностью <see cref="Entities.User"/>.
        /// </remarks>
        public virtual required User User { get; set; }

        /// <summary>
        /// Уникальный идентификатор связанной сущности <see cref="Entities.WorkTeamRole"/>
        /// </summary>
        public int WorkTeamRoleID { get; set; }

        /// <summary>
        /// Роль пользователя в рабочей группе
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "многие к одному" с сущностью <see cref="Entities.WorkTeamRole"/>.
        /// </remarks>
        public virtual required WorkTeamRole WorkTeamRole { get; set; }
    }
}
