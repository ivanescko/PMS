using MediatR;
using PMS.Server.DTOs.WorkTeamStatusDTO.Commands;

namespace PMS.Server.Repositories.WorkTeamStatusRepository.Handlers.Commands.UpdateWorkTeamStatus
{
    /// <summary>
    /// Обработчик команды <see cref="UpdateWorkTeamStatusCommand"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует обновление в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IWorkTeamStatusRepository"/>.</param>
    public class UpdateWorkTeamStatusCommandHandler(IWorkTeamStatusRepository repository) : IRequestHandler<UpdateWorkTeamStatusCommand>
    {
        private readonly IWorkTeamStatusRepository _repository = repository;

        /// <summary>
        /// Метод обработки команды <see cref="UpdateWorkTeamStatusCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для обновления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(UpdateWorkTeamStatusCommand command, CancellationToken cancellationToken)
        {
            await _repository.UpdateWorkTeamStatusAsync(
                id: command.Id,
                request: new UpdateWorkTeamStatusRequest
                {
                    Title = command.Title,
                    Description = command.Description,
                }
            );
        }
    }
}
