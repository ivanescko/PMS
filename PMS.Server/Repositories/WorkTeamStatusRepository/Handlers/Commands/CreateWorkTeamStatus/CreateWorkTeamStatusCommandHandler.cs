using MediatR;
using PMS.Server.DTOs.WorkTeamStatusDTO.Commands;

namespace PMS.Server.Repositories.WorkTeamStatusRepository.Handlers.Commands.CreateWorkTeamStatus
{
    /// <summary>
    /// Обработчик команды <see cref="CreateWorkTeamStatusCommand"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует создание сущности в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IWorkTeamStatusRepository"/>.</param>
    public class CreateWorkTeamStatusCommandHandler(IWorkTeamStatusRepository repository) : IRequestHandler<CreateWorkTeamStatusCommand>
    {
        private readonly IWorkTeamStatusRepository _repository = repository;

        /// <summary>
        /// Метод обработки команды <see cref="CreateWorkTeamStatusCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для создания.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(CreateWorkTeamStatusCommand command, CancellationToken cancellationToken)
        {
            var createWorkTeamStatusDto = new CreateWorkTeamStatusRequest
            {
                Title = command.Title,
                Description = command.Description,
            };

            await _repository.CreateWorkTeamStatusAsync(createWorkTeamStatusDto);
        }
    }
}
