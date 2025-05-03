using MediatR;

namespace PMS.Server.Repositories.UserRepository.Handlers.Commands.DeleteUser
{
    /// <summary>
    /// Обработчик команды <see cref="DeleteUserCommand"/>.
    /// </summary>
    /// <remarks>
    /// Делегирует удаление в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IUserRepository"/>.</param>
    public class DeleteUserCommandHandler(IUserRepository repository) : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _repository = repository;

        /// <summary>
        /// Метод обработки команды <see cref="DeleteUserCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для удаления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            await _repository.DeleteUserAsync(command.Id);
        }
    }
}
