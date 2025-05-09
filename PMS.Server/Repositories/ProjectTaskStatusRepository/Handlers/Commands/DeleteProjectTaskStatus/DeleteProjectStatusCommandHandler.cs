using MediatR;

namespace PMS.Server.Repositories.ProjectTaskStatusRepository.Handlers.Commands.DeleteProjectTaskStatus
{
    /// <summary>
    /// Обработчик команды <see cref="DeleteProjectTaskStatusCommand"/>.
    /// </summary>
    /// <remarks>
    /// Делегирует удаление в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IProjectTaskStatusRepository"/>.</param>
    public class DeleteProjectTaskStatusCommandHandler(IProjectTaskStatusRepository repository) : IRequestHandler<DeleteProjectTaskStatusCommand>
    {
        private readonly IProjectTaskStatusRepository _repository = repository;

        /// <summary>
        /// Метод обработки команды <see cref="DeleteProjectTaskStatusCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для удаления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(DeleteProjectTaskStatusCommand command, CancellationToken cancellationToken)
        {
            await _repository.DeleteProjectTaskStatusAsync(command.Id);
        }
    }
}
