using PMS.Server.DTOs.WorkTeamRoleDTO.Commands;
using PMS.Server.DTOs.WorkTeamRoleDTO.Queries;
using PMS.Server.Exceptions;

namespace PMS.Server.Repositories.WorkTeamRoleRepository
{
    /// <summary>
    /// Интерфейс репозитория для работы с ролями команд.
    /// </summary>
    /// <remarks>
    /// Описывает структуру репозитория для взаимодействия с сущностью ролей команд.
    /// </remarks>
    public interface IWorkTeamRoleRepository
    {
        /// <summary>
        /// Метод получения списка ролей команд.
        /// </summary>
        /// <returns>Список DTO с данными всех ролей команд.</returns>
        Task<List<GetWorkTeamRoleItemResponse>> GetWorkTeamRolesAsync();

        /// <summary>
        /// Метод получения роли команд по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор роли команд.</param>
        /// <returns>DTO с данными роли команд.</returns>
        /// <exception cref="BadRequestException">Невалидные данные.</exception>
        /// <exception cref="NotFoundException">Ресурс не найден.</exception>
        Task<GetWorkTeamRoleResponse> GetWorkTeamRoleByIdAsync(int id);

        /// <summary>
        /// Метод создания роли команд.
        /// </summary>
        /// <param name="request">Объект запроса, с данными новой роли команд.</param>
        /// <exception cref="ConflictException">Конфликт данных.</exception>
        Task CreateWorkTeamRoleAsync(CreateWorkTeamRoleRequest request);

        /// <summary>
        /// Метод изменения статуса роли.
        /// </summary>
        /// <param name="id">Идентификатор роли команд.</param>
        /// <param name="request">Объект запроса, с измененными данными роли команд.</param>
        /// <exception cref="NotFoundException">Ресурс не найден.</exception>
        /// <exception cref="ConflictException">Конфликт данных.</exception>
        Task UpdateWorkTeamRoleAsync(int id, UpdateWorkTeamRoleRequest request);

        /// <summary>
        /// Метод удаления роли команд.
        /// </summary>
        /// <param name="id">Идентификатор роли команд.</param>
        /// <exception cref="NotFoundException">Ресурс не найден.</exception>
        Task DeleteWorkTeamRoleAsync(int id);
    }
}
