using MediatR;

namespace PMS.Server.Repositories.UserRepository.Handlers.Commands.DeleteUser
{
    /// <summary>
    /// Обработчик команды <see cref="DeleteUserCommand"/>.
    /// </summary>
    /// <remarks>
    /// Делегирует удаление пользователя в репозиторий.
    /// </remarks>
    /// <param name="userRepository">Репозиторий реализующий интерфейс <see cref="IUserRepository"/>.</param>ы
    public class DeleteUserCommandHandler(IUserRepository userRepository) : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository = userRepository;

        /// <summary>
        /// Метод обработки команды <see cref="DeleteUserCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для создания пользователя.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteUserAsync(command.Id);
        }
    }
}
