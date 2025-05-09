using MediatR;
using PMS.Server.DTOs.SprintTaskStatusDTO.Commands;

namespace PMS.Server.Repositories.SprintTaskStatusRepository.Handlers.Commands.CreateSprintTaskStatus
{
    /// <summary>
    /// Обработчик команды <see cref="CreateSprintTaskStatusCommand"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует создание сущности в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="ISprintTaskStatusRepository"/>.</param>
    public class CreateSprintTaskStatusCommandHandler(ISprintTaskStatusRepository repository) : IRequestHandler<CreateSprintTaskStatusCommand>
    {
        private readonly ISprintTaskStatusRepository _repository = repository;

        /// <summary>
        /// Метод обработки команды <see cref="CreateSprintTaskStatusCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для создания.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(CreateSprintTaskStatusCommand command, CancellationToken cancellationToken)
        {
            var createSprintTaskStatusDto = new CreateSprintTaskStatusRequest
            {
                Title = command.Title,
                //Description = command.Description,
            };

            await _repository.CreateSprintTaskStatusAsync(createSprintTaskStatusDto);
        }
    }
}
