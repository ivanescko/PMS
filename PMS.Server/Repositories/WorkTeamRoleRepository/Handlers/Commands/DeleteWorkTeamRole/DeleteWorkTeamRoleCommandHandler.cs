using MediatR;

namespace PMS.Server.Repositories.WorkTeamRoleRepository.Handlers.Commands.DeleteWorkTeamRole
{
    /// <summary>
    /// Обработчик команды <see cref="DeleteWorkTeamRoleCommand"/>.
    /// </summary>
    /// <remarks>
    /// Делегирует удаление в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IWorkTeamRoleRepository"/>.</param>
    public class DeleteWorkTeamRoleCommandHandler(IWorkTeamRoleRepository repository) : IRequestHandler<DeleteWorkTeamRoleCommand>
    {
        private readonly IWorkTeamRoleRepository _repository = repository;

        /// <summary>
        /// Метод обработки команды <see cref="DeleteWorkTeamRoleCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для удаления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(DeleteWorkTeamRoleCommand command, CancellationToken cancellationToken)
        {
            await _repository.DeleteWorkTeamRoleAsync(command.Id);
        }
    }
}
