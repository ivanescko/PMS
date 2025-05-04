using PMS.Server.DTOs.DepartmentDTO.Commands;
using PMS.Server.DTOs.DepartmentDTO.Queries;
using PMS.Server.Exceptions;

namespace PMS.Server.Repositories.DepartmentRepository
{
    /// <summary>
    /// Интерфейс репозитория для работы с отделами.
    /// </summary>
    /// <remarks>
    /// Описывает структуру репозитория для взаимодействия с сущностью отдела.
    /// </remarks>
    public interface IDepartmentRepository
    {
        /// <summary>
        /// Метод получения списка отделов.
        /// </summary>
        /// <returns>Список DTO с данными всех отделов.</returns>
        Task<List<GetDepartmentItemResponse>> GetDepartmentsAsync();

        /// <summary>
        /// Метод получения отдела по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор отдела.</param>
        /// <returns>DTO с данными отдела.</returns>
        /// <exception cref="BadRequestException">Невалидные данные.</exception>
        /// <exception cref="NotFoundException">Ресурс не найден.</exception>
        Task<GetDepartmentResponse> GetDepartmentByIdAsync(int id);

        /// <summary>
        /// Метод создания отдела.
        /// </summary>
        /// <param name="request">Объект запроса, с данными нового отдела.</param>
        /// <exception cref="ConflictException">Конфликт данных.</exception>
        Task CreateDepartmentAsync(CreateDepartmentRequest request);

        /// <summary>
        /// Метод изменения отдела.
        /// </summary>
        /// <param name="id">Идентификатор отдела.</param>
        /// <param name="request">Объект запроса, с измененными данными отдела.</param>
        /// <exception cref="NotFoundException">Ресурс не найден.</exception>
        /// <exception cref="ConflictException">Конфликт данных.</exception>
        Task UpdateDepartmentAsync(int id, UpdateDepartmentRequest request);

        /// <summary>
        /// Метод удаления отдела.
        /// </summary>
        /// <param name="id">Идентификатор отдела.</param>
        /// <exception cref="NotFoundException">Ресурс не найден.</exception>
        Task DeleteDepartmentAsync(int id);
    }
}
