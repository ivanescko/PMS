using MediatR;

namespace PMS.Server.Repositories.SprintTaskStatusRepository.Handlers.Commands.DeleteSprintTaskStatus
{
    /// <summary>
    /// Обработчик команды <see cref="DeleteSprintTaskStatusCommand"/>.
    /// </summary>
    /// <remarks>
    /// Делегирует удаление в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="ISprintTaskStatusRepository"/>.</param>
    public class DeleteSprintTaskStatusCommandHandler(ISprintTaskStatusRepository repository) : IRequestHandler<DeleteSprintTaskStatusCommand>
    {
        private readonly ISprintTaskStatusRepository _repository = repository;

        /// <summary>
        /// Метод обработки команды <see cref="DeleteSprintTaskStatusCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для удаления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(DeleteSprintTaskStatusCommand command, CancellationToken cancellationToken)
        {
            await _repository.DeleteSprintTaskStatusAsync(command.Id);
        }
    }
}
