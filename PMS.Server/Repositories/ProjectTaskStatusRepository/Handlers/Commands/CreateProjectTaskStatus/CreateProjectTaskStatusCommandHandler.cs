using MediatR;
using PMS.Server.DTOs.ProjectTaskStatusDTO.Commands;

namespace PMS.Server.Repositories.ProjectTaskStatusRepository.Handlers.Commands.CreateProjectTaskStatus
{
    /// <summary>
    /// Обработчик команды <see cref="CreateProjectTaskStatusCommand"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует создание сущности в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IProjectTaskStatusRepository"/>.</param>
    public class CreateProjectTaskStatusCommandHandler(IProjectTaskStatusRepository repository) : IRequestHandler<CreateProjectTaskStatusCommand>
    {
        private readonly IProjectTaskStatusRepository _repository = repository;

        /// <summary>
        /// Метод обработки команды <see cref="CreateProjectTaskStatusCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для создания.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(CreateProjectTaskStatusCommand command, CancellationToken cancellationToken)
        {
            var createProjectTaskStatusDto = new CreateProjectTaskStatusRequest
            {
                Title = command.Title,
                Description = command.Description,
            };

            await _repository.CreateProjectTaskStatusAsync(createProjectTaskStatusDto);
        }
    }
}
