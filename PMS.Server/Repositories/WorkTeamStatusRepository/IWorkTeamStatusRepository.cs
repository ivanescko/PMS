using PMS.Server.DTOs.WorkTeamStatusDTO.Commands;
using PMS.Server.DTOs.WorkTeamStatusDTO.Queries;
using PMS.Server.Exceptions;

namespace PMS.Server.Repositories.WorkTeamStatusRepository
{
    /// <summary>
    /// Интерфейс репозитория для работы со статусами команд.
    /// </summary>
    /// <remarks>
    /// Описывает структуру репозитория для взаимодействия с сущностью статуса команд.
    /// </remarks>
    public interface IWorkTeamStatusRepository
    {
        /// <summary>
        /// Метод получения списка статусов команд.
        /// </summary>
        /// <returns>Список DTO с данными всех статусов команд.</returns>
        Task<List<GetWorkTeamStatusItemResponse>> GetWorkTeamStatusesAsync();

        /// <summary>
        /// Метод получения статуса команд по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор статуса команд.</param>
        /// <returns>DTO с данными статуса команд.</returns>
        /// <exception cref="BadRequestException">Невалидные данные.</exception>
        /// <exception cref="NotFoundException">Ресурс не найден.</exception>
        Task<GetWorkTeamStatusResponse> GetWorkTeamStatusByIdAsync(int id);

        /// <summary>
        /// Метод создания статуса команд.
        /// </summary>
        /// <param name="request">Объект запроса, с данными новой статуса команд.</param>
        /// <exception cref="ConflictException">Конфликт данных.</exception>
        Task CreateWorkTeamStatusAsync(CreateWorkTeamStatusRequest request);

        /// <summary>
        /// Метод изменения статуса команд.
        /// </summary>
        /// <param name="id">Идентификатор статуса команд.</param>
        /// <param name="request">Объект запроса, с измененными данными статуса команд.</param>
        /// <exception cref="NotFoundException">Ресурс не найден.</exception>
        /// <exception cref="ConflictException">Конфликт данных.</exception>
        Task UpdateWorkTeamStatusAsync(int id, UpdateWorkTeamStatusRequest request);

        /// <summary>
        /// Метод удаления статуса команд.
        /// </summary>
        /// <param name="id">Идентификатор статуса команд.</param>
        /// <exception cref="NotFoundException">Ресурс не найден.</exception>
        Task DeleteWorkTeamStatusAsync(int id);
    }
}
