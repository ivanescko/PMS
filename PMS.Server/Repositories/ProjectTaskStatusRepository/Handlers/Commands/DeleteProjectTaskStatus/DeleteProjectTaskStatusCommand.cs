using MediatR;

namespace PMS.Server.Repositories.ProjectTaskStatusRepository.Handlers.Commands.DeleteProjectTaskStatus
{
    /// <summary>
    /// Команда удаления статуса задач проекта.
    /// </summary>
    /// <param name="Id">Идентификатор статуса задач проекта.</param>
    public sealed record DeleteProjectTaskStatusCommand(int Id) : IRequest;
}
