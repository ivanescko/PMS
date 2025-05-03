using PMS.Server.DTOs.UserDTO.Commands;
using PMS.Server.DTOs.UserDTO.Queries;
using PMS.Server.Exceptions;

namespace PMS.Server.Repositories.UserRepository
{
    /// <summary>
    /// Интерфейс репозитория для работы с пользователями.
    /// </summary>
    /// <remarks>
    /// Описывает структуру репозитория для взаимодействия с сущностью пользователя.
    /// </remarks>
    public interface IUserRepository
    {
        /// <summary>
        /// Метод получения списка пользователей.
        /// </summary>
        /// <returns>Список DTO с данными всех пользователей.</returns>
        Task<List<GetUserItemResponse>> GetUsersAsync();

        /// <summary>
        /// Метод получения пользователя по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns>DTO с данными пользователя.</returns>
        /// <exception cref="BadRequestException">Невалидные данные.</exception>
        /// <exception cref="NotFoundException">Ресурс не найден.</exception>
        Task<GetUserResponse> GetUserByIdAsync(int id);

        /// <summary>
        /// Метод создания пользователя.
        /// </summary>
        /// <param name="request">Объект запроса, с данными нового пользователя.</param>
        /// <exception cref="ConflictException">Конфликт данных.</exception>
        Task CreateUserAsync(CreateUserRequest request);

        /// <summary>
        /// Метод изменения пользователя.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="request">Объект запроса, с измененными данными пользователя.</param>
        /// <exception cref="NotFoundException">Ресурс не найден.</exception>
        /// <exception cref="ConflictException">Конфликт данных.</exception>
        Task UpdateUserAsync(int id, UpdateUserRequest request);

        /// <summary>
        /// Метод удаления пользователя.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <exception cref="NotFoundException">Ресурс не найден.</exception>
        Task DeleteUserAsync(int id);
    }
}
