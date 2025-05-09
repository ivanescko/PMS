using MediatR;

namespace PMS.Server.Repositories.ProjectStatusRepository.Handlers.Commands.DeleteProjectStatus
{
    /// <summary>
    /// Команда удаления статуса проекта.
    /// </summary>
    /// <param name="Id">Идентификатор статуса проекта.</param>
    public sealed record DeleteProjectStatusCommand(int Id) : IRequest;
}
