using MediatR;

namespace PMS.Server.Repositories.SprintTaskStatusRepository.Handlers.Commands.DeleteSprintTaskStatus
{
    /// <summary>
    /// Команда удаления статуса задач спринта.
    /// </summary>
    /// <param name="Id">Идентификатор статуса задач спринта.</param>
    public sealed record DeleteSprintTaskStatusCommand(int Id) : IRequest;
}
