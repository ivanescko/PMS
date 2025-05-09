using MediatR;

namespace PMS.Server.Repositories.ProjectStatusRepository.Handlers.Commands.UpdateProjectStatus
{
    /// <summary>
    /// Команда обновления статуса проекта.
    /// </summary>
    /// <param name="Id">Идентификатор.</param>
    /// <param name="Title">Наименование.</param>
    /// <param name="Description">Описание.</param>
    public sealed record UpdateProjectStatusCommand(
        int Id,
        string? Title,
        string? Description
    ) : IRequest;
}
