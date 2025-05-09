using MediatR;

namespace PMS.Server.Repositories.WorkTeamStatusRepository.Handlers.Commands.DeleteWorkTeamStatus
{
    /// <summary>
    /// Команда удаления статуса команд.
    /// </summary>
    /// <param name="Id">Идентификатор статуса команд.</param>
    public sealed record DeleteWorkTeamStatusCommand(int Id) : IRequest;
}
