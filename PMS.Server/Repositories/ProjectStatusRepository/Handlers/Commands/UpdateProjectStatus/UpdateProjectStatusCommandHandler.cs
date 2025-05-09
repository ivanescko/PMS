using MediatR;
using PMS.Server.DTOs.ProjectStatusDTO.Commands;

namespace PMS.Server.Repositories.ProjectStatusRepository.Handlers.Commands.UpdateProjectStatus
{
    /// <summary>
    /// Обработчик команды <see cref="UpdateProjectStatusCommand"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует обновление в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IProjectStatusRepository"/>.</param>
    public class UpdateProjectStatusCommandHandler(IProjectStatusRepository repository) : IRequestHandler<UpdateProjectStatusCommand>
    {
        private readonly IProjectStatusRepository _repository = repository;

        /// <summary>
        /// Метод обработки команды <see cref="UpdateProjectStatusCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для обновления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(UpdateProjectStatusCommand command, CancellationToken cancellationToken)
        {
            await _repository.UpdateProjectStatusAsync(
                id: command.Id,
                request: new UpdateProjectStatusRequest
                {
                    Title = command.Title,
                    Description = command.Description,
                }
            );
        }
    }
}
