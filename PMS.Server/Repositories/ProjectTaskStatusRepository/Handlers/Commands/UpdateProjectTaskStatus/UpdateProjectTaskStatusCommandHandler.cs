using MediatR;
using PMS.Server.DTOs.ProjectTaskStatusDTO.Commands;

namespace PMS.Server.Repositories.ProjectTaskStatusRepository.Handlers.Commands.UpdateProjectTaskStatus
{
    /// <summary>
    /// Обработчик команды <see cref="UpdateProjectTaskStatusCommand"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует обновление в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IProjectTaskStatusRepository"/>.</param>
    public class UpdateProjectTaskStatusCommandHandler(IProjectTaskStatusRepository repository) : IRequestHandler<UpdateProjectTaskStatusCommand>
    {
        private readonly IProjectTaskStatusRepository _repository = repository;

        /// <summary>
        /// Метод обработки команды <see cref="UpdateProjectTaskStatusCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для обновления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(UpdateProjectTaskStatusCommand command, CancellationToken cancellationToken)
        {
            await _repository.UpdateProjectTaskStatusAsync(
                id: command.Id,
                request: new UpdateProjectTaskStatusRequest
                {
                    Title = command.Title,
                    Description = command.Description,
                }
            );
        }
    }
}
