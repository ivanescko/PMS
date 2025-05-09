using MediatR;

namespace PMS.Server.Repositories.WorkTeamStatusRepository.Handlers.Commands.UpdateWorkTeamStatus
{
    /// <summary>
    /// Команда обновления статуса команд.
    /// </summary>
    /// <param name="Id">Идентификатор.</param>
    /// <param name="Title">Наименование.</param>
    /// <param name="Description">Описание.</param>
    public sealed record UpdateWorkTeamStatusCommand(
        int Id,
        string? Title,
        string? Description
    ) : IRequest;
}
