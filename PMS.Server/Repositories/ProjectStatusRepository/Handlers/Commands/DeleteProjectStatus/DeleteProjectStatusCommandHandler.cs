using MediatR;

namespace PMS.Server.Repositories.ProjectStatusRepository.Handlers.Commands.DeleteProjectStatus
{
    /// <summary>
    /// Обработчик команды <see cref="DeleteProjectStatusCommand"/>.
    /// </summary>
    /// <remarks>
    /// Делегирует удаление в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IProjectStatusRepository"/>.</param>
    public class DeleteProjectStatusCommandHandler(IProjectStatusRepository repository) : IRequestHandler<DeleteProjectStatusCommand>
    {
        private readonly IProjectStatusRepository _repository = repository;

        /// <summary>
        /// Метод обработки команды <see cref="DeleteProjectStatusCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для удаления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(DeleteProjectStatusCommand command, CancellationToken cancellationToken)
        {
            await _repository.DeleteProjectStatusAsync(command.Id);
        }
    }
}
