using MediatR;
using PMS.Server.DTOs.WorkTeamRoleDTO.Commands;

namespace PMS.Server.Repositories.WorkTeamRoleRepository.Handlers.Commands.UpdateWorkTeamRole
{
    /// <summary>
    /// Обработчик команды <see cref="UpdateWorkTeamRoleCommand"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует обновление в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IWorkTeamRoleRepository"/>.</param>
    public class UpdateWorkTeamRoleCommandHandler(IWorkTeamRoleRepository repository) : IRequestHandler<UpdateWorkTeamRoleCommand>
    {
        private readonly IWorkTeamRoleRepository _repository = repository;

        /// <summary>
        /// Метод обработки команды <see cref="UpdateWorkTeamRoleCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для обновления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(UpdateWorkTeamRoleCommand command, CancellationToken cancellationToken)
        {
            await _repository.UpdateWorkTeamRoleAsync(
                id: command.Id,
                request: new UpdateWorkTeamRoleRequest
                {
                    Title = command.Title,
                    Description = command.Description,
                }
            );
        }
    }
}
