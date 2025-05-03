using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.Model.Entities
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Уникальный идентификатор сотрудника
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }

        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public required string FirstName { get; set; }

        /// <summary>
        /// Отчество сотрудника
        /// </summary>
        public required string SecondName { get; set; }

        /// <summary>
        /// Фамилия сотрудника
        /// </summary>
        public string? Surname { get; set; }

        /// <summary>
        /// Пол сотрудника
        /// </summary>
        public bool Gender { get; set; }

        /// <summary>
        /// Дата рождения сотрудника
        /// </summary>
        public DateOnly Birthdate { get; set; }

        /// <summary>
        /// Уникальный идентификатор связанной сущности <see cref="Entities.Speciality"/>
        /// </summary>
        public int? SpecialityID { get; set; }

        /// <summary>
        /// Специальность
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "многие к одному" с сущностью <see cref="Entities.Speciality"/>.
        /// </remarks>
        public virtual Speciality? Speciality { get; set; }

        /// <summary>
        /// Уникальный идентификатор связанной сущности <see cref="Entities.Department"/>
        /// </summary>
        public int? DepartmentID { get; set; }

        /// <summary>
        /// Отдел
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "многие к одному" с сущностью <see cref="Entities.Department"/>.
        /// </remarks>
        public virtual Department? Department { get; set; }

        /// <summary>
        /// Уникальный идентификатор связанной сущности <see cref="Entities.User"/>
        /// </summary>
        public int? UserID { get; set; }        

        /// <summary>
        /// Пользователь
        /// </summary>
        /// <remarks>
        /// Навигационное свойство представляет связь "один к одному" с сущностью <see cref="Entities.User"/>.
        /// </remarks>
        public virtual User? User { get; set; }
    }
}
