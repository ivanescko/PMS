namespace PMS.Model.Entities
{
    /// <summary>
    /// Версия проекта
    /// </summary>
    public class ProjectRelease
    {
        /// <summary>
        /// Уникальный идентификатор версии проекта
        /// </summary>
        public int ProjectReleaseID { get; set; }

        /// <summary>
        /// Версия
        /// </summary>
        public required string Version { get; set; }

        /// <summary>
        /// Уникальный идентификатор связанной сущности <see cref="Entities.Project"/>
        /// </summary>
        public required int ProjectID { get; set; }

        /// <summary>
        /// Проект
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "многие к одному" с сущностью <see cref="Entities.Project"/>.
        /// </remarks>
        public required Project Project { get; set; }

        /// <summary>
        /// Список задач
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "один ко многим" с сущностью <see cref="ProjectTask"/>.
        /// </remarks>
        public ICollection<ProjectTask> ProjectTasks { get; set; } = new List<ProjectTask>();
    }
}
