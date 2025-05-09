using MediatR;
using PMS.Server.DTOs.SprintTaskStatusDTO.Commands;

namespace PMS.Server.Repositories.SprintTaskStatusRepository.Handlers.Commands.UpdateSprintTaskStatus
{
    /// <summary>
    /// Обработчик команды <see cref="UpdateSprintTaskStatusCommand"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует обновление в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="ISprintTaskStatusRepository"/>.</param>
    public class UpdateSprintTaskStatusCommandHandler(ISprintTaskStatusRepository repository) : IRequestHandler<UpdateSprintTaskStatusCommand>
    {
        private readonly ISprintTaskStatusRepository _repository = repository;

        /// <summary>
        /// Метод обработки команды <see cref="UpdateSprintTaskStatusCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для обновления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(UpdateSprintTaskStatusCommand command, CancellationToken cancellationToken)
        {
            await _repository.UpdateSprintTaskStatusAsync(
                id: command.Id,
                request: new UpdateSprintTaskStatusRequest
                {
                    Title = command.Title,
                    //Description = command.Description,
                }
            );
        }
    }
}
