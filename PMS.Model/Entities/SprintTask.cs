namespace PMS.Model.Entities
{
    /// <summary>
    /// Задача спринта
    /// </summary>
    public class SprintTask
    {
        /// <summary>
        /// Уникальный идентификатор связанной сущности <see cref="Entities.Sprint"/>
        /// </summary>
        public required int SprintID { get; set; }

        /// <summary>
        /// Спринт
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "многие ко многим" с сущностью <see cref="Entities.Sprint"/>.
        /// </remarks>
        public required Sprint Sprint { get; set; }

        /// <summary>
        /// Уникальный идентификатор связанной сущности <see cref="Entities.ProjectTask"/>
        /// </summary>
        public required int ProjectTaskID { get; set; }

        /// <summary>
        /// Задача
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "многие ко многим" с сущностью <see cref="Entities.ProjectTask"/>.
        /// </remarks>
        public required ProjectTask ProjectTask { get; set; }

        /// <summary>
        /// Уникальный идентификатор связанной сущности <see cref="Entities.SprintTaskStatus"/>
        /// </summary>
        public required int SprintTaskStatusID { get; set; }

        /// <summary>
        /// Статус задачи спринта
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "многие к одному" с сущностью <see cref="Entities.SprintTaskStatus"/>.
        /// </remarks>
        public required SprintTaskStatus SprintTaskStatus { get; set; }
    }
}
