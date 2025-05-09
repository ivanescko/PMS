using MediatR;
using PMS.Server.DTOs.WorkTeamRoleDTO.Commands;

namespace PMS.Server.Repositories.WorkTeamRoleRepository.Handlers.Commands.CreateWorkTeamRole
{
    /// <summary>
    /// Обработчик команды <see cref="CreateWorkTeamRoleCommand"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует создание сущности в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IWorkTeamRoleRepository"/>.</param>
    public class CreateWorkTeamRoleCommandHandler(IWorkTeamRoleRepository repository) : IRequestHandler<CreateWorkTeamRoleCommand>
    {
        private readonly IWorkTeamRoleRepository _repository = repository;

        /// <summary>
        /// Метод обработки команды <see cref="CreateWorkTeamRoleCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для создания.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(CreateWorkTeamRoleCommand command, CancellationToken cancellationToken)
        {
            var createWorkTeamRoleDto = new CreateWorkTeamRoleRequest
            {
                Title = command.Title,
                Description = command.Description,
            };

            await _repository.CreateWorkTeamRoleAsync(createWorkTeamRoleDto);
        }
    }
}
