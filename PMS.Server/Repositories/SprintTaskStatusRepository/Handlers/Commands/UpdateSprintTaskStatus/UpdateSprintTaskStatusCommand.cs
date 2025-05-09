using MediatR;

namespace PMS.Server.Repositories.SprintTaskStatusRepository.Handlers.Commands.UpdateSprintTaskStatus
{
    /// <summary>
    /// Команда обновления статуса задач спринта.
    /// </summary>
    /// <param name="Id">Идентификатор.</param>
    /// <param name="Title">Наименование.</param>
    public sealed record UpdateSprintTaskStatusCommand(
        int Id,
        string? Title
        //string? Description
    ) : IRequest;
}
