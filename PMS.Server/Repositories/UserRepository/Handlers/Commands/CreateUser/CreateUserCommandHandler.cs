using MediatR;
using PMS.Server.DTOs.UserDTO.Commands;

namespace PMS.Server.Repositories.UserRepository.Handlers.Commands.CreateUser
{
    /// <summary>
    /// Обработчик команды <see cref="CreateUserCommand"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует создание пользователя в репозиторий.
    /// </remarks>
    /// <param name="userRepository">Репозиторий реализующий интерфейс <see cref="IUserRepository"/>.</param>
    public class CreateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository = userRepository;

        /// <summary>
        /// Метод обработки команды <see cref="CreateUserCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для создания пользователя.</param>
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

            await _userRepository.CreateUserAsync(createUserDto);
        }
    }
}
