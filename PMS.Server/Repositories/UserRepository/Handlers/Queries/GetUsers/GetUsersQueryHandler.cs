using AutoMapper;
using MediatR;
using PMS.Server.DTOs.UserDTO.Queries;

namespace PMS.Server.Repositories.UserRepository.Handlers.Queries.GetUsers
{
    /// <summary>
    /// Обработчик команды <see cref="GetUsersQuery"/>.
    /// </summary>
    /// <remarks>
    /// Делегирует запрос на получение списка пользователей в репозиторий.
    /// </remarks>
    /// <param name="userRepository">Репозиторий реализующий интерфейс <see cref="IUserRepository"/>.</param>
    public class GetUsersQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUsersQuery, List<GetUsersItemResponse>>
    {
        private readonly IUserRepository _userRepository = userRepository;

        /// <summary>
        /// Метод обработки запроса <see cref="GetUsersQuery"/>.
        /// </summary>
        /// <returns>Список объектов <see cref="GetUsersItemResponse"/>.</returns>
        /// <param name="request">Запрос на получение списка пользователей.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task<List<GetUsersItemResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUsersAsync();
        }
    }
}
