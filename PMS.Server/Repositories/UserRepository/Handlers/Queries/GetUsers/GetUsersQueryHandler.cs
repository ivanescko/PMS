using MediatR;
using PMS.Server.DTOs.UserDTO.Queries;

namespace PMS.Server.Repositories.UserRepository.Handlers.Queries.GetUsers
{
    /// <summary>
    /// Обработчик команды <see cref="GetUsersQuery"/>.
    /// </summary>
    /// <remarks>
    /// Делегирует запрос на получение списка в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IUserRepository"/>.</param>
    public class GetUsersQueryHandler(IUserRepository repository) : IRequestHandler<GetUsersQuery, List<GetUserItemResponse>>
    {
        private readonly IUserRepository _repository = repository;

        /// <summary>
        /// Метод обработки запроса <see cref="GetUsersQuery"/>.
        /// </summary>
        /// <returns>Список объектов <see cref="GetUserItemResponse"/>.</returns>
        /// <param name="request">Запрос на получение списка.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task<List<GetUserItemResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetUsersAsync();
        }
    }
}
