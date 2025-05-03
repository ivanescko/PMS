using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.Model.Entities
{
    /// <summary>
    /// Отдел
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Уникальный идентификатор отдела
        /// </summary>
        public int DepartmentID { get; set; }

        /// <summary>
        /// Код отдела
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Наименование отдела
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Описание отдела
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Коллекция сотрудников, свазнных с сущностью <see cref="Department"/>
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "один ко многим" с сущностью <see cref="Employee"/>.
        /// </remarks>
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
