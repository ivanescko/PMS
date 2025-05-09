using MediatR;
using PMS.Server.DTOs.ProjectStatusDTO.Commands;

namespace PMS.Server.Repositories.ProjectStatusRepository.Handlers.Commands.CreateProjectStatus
{
    /// <summary>
    /// Обработчик команды <see cref="CreateProjectStatusCommand"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует создание сущности в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IProjectStatusRepository"/>.</param>
    public class CreateProjectStatusCommandHandler(IProjectStatusRepository repository) : IRequestHandler<CreateProjectStatusCommand>
    {
        private readonly IProjectStatusRepository _repository = repository;

        /// <summary>
        /// Метод обработки команды <see cref="CreateProjectStatusCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для создания.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(CreateProjectStatusCommand command, CancellationToken cancellationToken)
        {
            var createProjectStatusDto = new CreateProjectStatusRequest
            {
                Title = command.Title,
                Description = command.Description,
            };

            await _repository.CreateProjectStatusAsync(createProjectStatusDto);
        }
    }
}
