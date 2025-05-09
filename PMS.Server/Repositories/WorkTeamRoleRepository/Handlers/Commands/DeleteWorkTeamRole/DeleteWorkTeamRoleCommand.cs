using MediatR;

namespace PMS.Server.Repositories.WorkTeamRoleRepository.Handlers.Commands.DeleteWorkTeamRole
{
    /// <summary>
    /// Команда удаления роли команд.
    /// </summary>
    /// <param name="Id">Идентификатор роли команд.</param>
    public sealed record DeleteWorkTeamRoleCommand(int Id) : IRequest;
}
