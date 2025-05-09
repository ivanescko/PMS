using MediatR;

namespace PMS.Server.Repositories.ProjectTaskStatusRepository.Handlers.Commands.UpdateProjectTaskStatus
{
    /// <summary>
    /// Команда обновления статуса задач проекта.
    /// </summary>
    /// <param name="Id">Идентификатор.</param>
    /// <param name="Title">Наименование.</param>
    /// <param name="Description">Описание.</param>
    public sealed record UpdateProjectTaskStatusCommand(
        int Id,
        string? Title,
        string? Description
    ) : IRequest;
}
