using PMS.Server.DTOs.ProjectTaskStatusDTO.Commands;
using PMS.Server.DTOs.ProjectTaskStatusDTO.Queries;
using PMS.Server.Exceptions;

namespace PMS.Server.Repositories.ProjectTaskStatusRepository
{
    /// <summary>
    /// Интерфейс репозитория для работы со статусами задач проектов.
    /// </summary>
    /// <remarks>
    /// Описывает структуру репозитория для взаимодействия с сущностью статуса задач проекта.
    /// </remarks>
    public interface IProjectTaskStatusRepository
    {
        /// <summary>
        /// Метод получения списка статусов задач проектов.
        /// </summary>
        /// <returns>Список DTO с данными всех статусов задач проектов.</returns>
        Task<List<GetProjectTaskStatusItemResponse>> GetProjectTaskStatusesAsync();

        /// <summary>
        /// Метод получения статуса задач проекта по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор статуса задач проекта.</param>
        /// <returns>DTO с данными статуса задач проекта.</returns>
        /// <exception cref="BadRequestException">Невалидные данные.</exception>
        /// <exception cref="NotFoundException">Ресурс не найден.</exception>
        Task<GetProjectTaskStatusResponse> GetProjectTaskStatusByIdAsync(int id);

        /// <summary>
        /// Метод создания статуса задач проекта.
        /// </summary>
        /// <param name="request">Объект запроса, с данными новой статуса задач проекта.</param>
        /// <exception cref="ConflictException">Конфликт данных.</exception>
        Task CreateProjectTaskStatusAsync(CreateProjectTaskStatusRequest request);

        /// <summary>
        /// Метод изменения статуса задач проекта.
        /// </summary>
        /// <param name="id">Идентификатор статуса задач проекта.</param>
        /// <param name="request">Объект запроса, с измененными данными статуса задач проекта.</param>
        /// <exception cref="NotFoundException">Ресурс не найден.</exception>
        /// <exception cref="ConflictException">Конфликт данных.</exception>
        Task UpdateProjectTaskStatusAsync(int id, UpdateProjectTaskStatusRequest request);

        /// <summary>
        /// Метод удаления статуса задач проекта.
        /// </summary>
        /// <param name="id">Идентификатор статуса задач проекта.</param>
        /// <exception cref="NotFoundException">Ресурс не найден.</exception>
        Task DeleteProjectTaskStatusAsync(int id);
    }
}
