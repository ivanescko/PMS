using MediatR;

namespace PMS.Server.Repositories.WorkTeamRoleRepository.Handlers.Commands.CreateWorkTeamRole
{
    /// <summary>
    /// Команда создания новой роли команд.
    /// </summary>
    /// <param name="Title">Наименование.</param>
    /// <param name="Description">Описание.</param>
    public sealed record CreateWorkTeamRoleCommand(
        string Title,
        string Description
    ) : IRequest;
}
