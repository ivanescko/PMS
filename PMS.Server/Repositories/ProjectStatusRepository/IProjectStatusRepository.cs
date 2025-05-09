using PMS.Server.DTOs.ProjectStatusDTO.Commands;
using PMS.Server.DTOs.ProjectStatusDTO.Queries;
using PMS.Server.Exceptions;

namespace PMS.Server.Repositories.ProjectStatusRepository
{
    /// <summary>
    /// Интерфейс репозитория для работы со статусами проектов.
    /// </summary>
    /// <remarks>
    /// Описывает структуру репозитория для взаимодействия с сущностью статуса проекта.
    /// </remarks>
    public interface IProjectStatusRepository
    {
        /// <summary>
        /// Метод получения списка статусов проектов.
        /// </summary>
        /// <returns>Список DTO с данными всех статусов проектов.</returns>
        Task<List<GetProjectStatusItemResponse>> GetProjectStatusesAsync();

        /// <summary>
        /// Метод получения статуса проекта по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор статуса проекта.</param>
        /// <returns>DTO с данными статуса проекта.</returns>
        /// <exception cref="BadRequestException">Невалидные данные.</exception>
        /// <exception cref="NotFoundException">Ресурс не найден.</exception>
        Task<GetProjectStatusResponse> GetProjectStatusByIdAsync(int id);

        /// <summary>
        /// Метод создания статуса проекта.
        /// </summary>
        /// <param name="request">Объект запроса, с данными новой статуса проекта.</param>
        /// <exception cref="ConflictException">Конфликт данных.</exception>
        Task CreateProjectStatusAsync(CreateProjectStatusRequest request);

        /// <summary>
        /// Метод изменения статуса проекта.
        /// </summary>
        /// <param name="id">Идентификатор статуса проекта.</param>
        /// <param name="request">Объект запроса, с измененными данными статуса проекта.</param>
        /// <exception cref="NotFoundException">Ресурс не найден.</exception>
        /// <exception cref="ConflictException">Конфликт данных.</exception>
        Task UpdateProjectStatusAsync(int id, UpdateProjectStatusRequest request);

        /// <summary>
        /// Метод удаления статуса проекта.
        /// </summary>
        /// <param name="id">Идентификатор статуса проекта.</param>
        /// <exception cref="NotFoundException">Ресурс не найден.</exception>
        Task DeleteProjectStatusAsync(int id);
    }
}
