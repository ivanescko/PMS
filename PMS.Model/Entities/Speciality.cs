namespace PMS.Model.Entities
{
    /// <summary>
    /// Специальность
    /// </summary>
    public class Speciality
    {
        /// <summary>
        /// Уникальный идентификатор специальности
        /// </summary>
        public int SpecialityID { get; set; }

        /// <summary>
        /// Наименование специальности
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Описание специальности
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Список сотрудников
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "один ко многим" с сущностью <see cref="Employee"/>.
        /// </remarks>
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
