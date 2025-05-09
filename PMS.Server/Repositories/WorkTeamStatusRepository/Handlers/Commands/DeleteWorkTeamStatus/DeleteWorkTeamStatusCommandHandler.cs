using MediatR;

namespace PMS.Server.Repositories.WorkTeamStatusRepository.Handlers.Commands.DeleteWorkTeamStatus
{
    /// <summary>
    /// Обработчик команды <see cref="DeleteWorkTeamStatusCommand"/>.
    /// </summary>
    /// <remarks>
    /// Делегирует удаление в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IWorkTeamStatusRepository"/>.</param>
    public class DeleteWorkTeamStatusCommandHandler(IWorkTeamStatusRepository repository) : IRequestHandler<DeleteWorkTeamStatusCommand>
    {
        private readonly IWorkTeamStatusRepository _repository = repository;

        /// <summary>
        /// Метод обработки команды <see cref="DeleteWorkTeamStatusCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для удаления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(DeleteWorkTeamStatusCommand command, CancellationToken cancellationToken)
        {
            await _repository.DeleteWorkTeamStatusAsync(command.Id);
        }
    }
}
