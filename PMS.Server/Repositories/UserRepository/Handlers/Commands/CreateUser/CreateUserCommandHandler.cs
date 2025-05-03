using MediatR;
using PMS.Server.DTOs.UserDTO.Commands;

namespace PMS.Server.Repositories.UserRepository.Handlers.Commands.CreateUser
{
    /// <summary>
    /// Обработчик команды <see cref="CreateUserCommand"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует создание сущности в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IUserRepository"/>.</param>
    public class CreateUserCommandHandler(IUserRepository repository) : IRequestHandler<CreateUserCommand>
    {
        private readonly IUserRepository _repository = repository;

        /// <summary>
        /// Метод обработки команды <see cref="CreateUserCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для создания.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var createUserDto = new CreateUserRequest
            {
                Login = command.Login,
                Password = command.Password,
                Name = command.Name,
                IsActive = command.IsActive
            };

            await _repository.CreateUserAsync(createUserDto);
        }
    }
}
