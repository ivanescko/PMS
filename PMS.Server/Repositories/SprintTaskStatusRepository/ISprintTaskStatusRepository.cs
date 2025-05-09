using PMS.Server.DTOs.SprintTaskStatusDTO.Commands;
using PMS.Server.DTOs.SprintTaskStatusDTO.Queries;
using PMS.Server.Exceptions;

namespace PMS.Server.Repositories.SprintTaskStatusRepository
{
    /// <summary>
    /// Интерфейс репозитория для работы со статусами задач спринта.
    /// </summary>
    /// <remarks>
    /// Описывает структуру репозитория для взаимодействия с сущностью статуса задач спринта.
    /// </remarks>
    public interface ISprintTaskStatusRepository
    {
        /// <summary>
        /// Метод получения списка статусов задач спринта.
        /// </summary>
        /// <returns>Список DTO с данными всех статусов задач спринта.</returns>
        Task<List<GetSprintTaskStatusItemResponse>> GetSprintTaskStatusesAsync();

        /// <summary>
        /// Метод получения статуса задач спринта по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор статуса задач спринта.</param>
        /// <returns>DTO с данными статуса задач спринта.</returns>
        /// <exception cref="BadRequestException">Невалидные данные.</exception>
        /// <exception cref="NotFoundException">Ресурс не найден.</exception>
        Task<GetSprintTaskStatusResponse> GetSprintTaskStatusByIdAsync(int id);

        /// <summary>
        /// Метод создания статуса задач спринта.
        /// </summary>
        /// <param name="request">Объект запроса, с данными новой статуса задач спринта.</param>
        /// <exception cref="ConflictException">Конфликт данных.</exception>
        Task CreateSprintTaskStatusAsync(CreateSprintTaskStatusRequest request);

        /// <summary>
        /// Метод изменения статуса задач спринта.
        /// </summary>
        /// <param name="id">Идентификатор статуса задач спринта.</param>
        /// <param name="request">Объект запроса, с измененными данными статуса задач спринта.</param>
        /// <exception cref="NotFoundException">Ресурс не найден.</exception>
        /// <exception cref="ConflictException">Конфликт данных.</exception>
        Task UpdateSprintTaskStatusAsync(int id, UpdateSprintTaskStatusRequest request);

        /// <summary>
        /// Метод удаления статуса задач спринта.
        /// </summary>
        /// <param name="id">Идентификатор статуса задач спринта.</param>
        /// <exception cref="NotFoundException">Ресурс не найден.</exception>
        Task DeleteSprintTaskStatusAsync(int id);
    }
}
