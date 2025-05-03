using MediatR;
using PMS.Server.DTOs.UserDTO.Queries;

namespace PMS.Server.Repositories.UserRepository.Handlers.Queries.GetUser
{
    /// <summary>
    /// Обработчик команды <see cref="GetUserQuery"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует запрос на получение данных в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IUserRepository"/>.</param>
    public class GetUserQueryHandler(IUserRepository repository) : IRequestHandler<GetUserQuery, GetUserResponse>
    {
        private readonly IUserRepository _repository = repository;

        /// <summary>
        /// Метод обработки запроса <see cref="GetUserQuery"/>.
        /// </summary>
        /// <returns>Объект с данными <see cref="GetUserResponse"/>.</returns>
        /// <param name="request">Запрос на получение данных.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>        
        public async Task<GetUserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetUserByIdAsync(request.Id);
        }
    }
}
