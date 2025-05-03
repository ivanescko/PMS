namespace PMS.Model.Entities
{
    /// <summary>
    /// Спринт
    /// </summary>
    public class Sprint
    {
        /// <summary>
        /// Уникальный идентификатор спринта
        /// </summary>
        public int SprintID { get; set; }

        /// <summary>
        /// Дата начала спринта
        /// </summary>
        public required DateOnly StartDate { get; set; }

        /// <summary>
        /// Дата окончания спринта
        /// </summary>
        public required DateOnly EndDate { get; set; }

        /// <summary>
        /// Цель спринта
        /// </summary>
        public string? Goal { get; set; }

        /// <summary>
        /// Уникальный идентификатор связанной сущности <see cref="Project"/>
        /// </summary>
        public required int ProjectID { get; set; }

        /// <summary>
        /// Проект текущего спринта
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "многие к одному" с сущностью <see cref="Entities.Project"/>.
        /// </remarks>
        public required Project Project { get; set; }
    }
}
