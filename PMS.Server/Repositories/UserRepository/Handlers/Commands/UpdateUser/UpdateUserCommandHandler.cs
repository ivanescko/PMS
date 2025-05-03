using MediatR;
using PMS.Server.DTOs.UserDTO.Commands;

namespace PMS.Server.Repositories.UserRepository.Handlers.Commands.UpdateUser
{
    /// <summary>
    /// Обработчик команды <see cref="UpdateUserCommand"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует обновление в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IUserRepository"/>.</param>
    public class UpdateUserCommandHandler(IUserRepository repository) : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _repository = repository;

        /// <summary>
        /// Метод обработки команды <see cref="UpdateUserCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для обновления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            await _repository.UpdateUserAsync(
                id: command.Id,
                request: new UpdateUserRequest
                {
                    Login = command.Login,
                    Password = command.Password,
                    Name = command.Name,
                    IsActive = command.IsActive
                }
            );
        }
    }
}
