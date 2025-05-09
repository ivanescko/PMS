using MediatR;

namespace PMS.Server.Repositories.WorkTeamRoleRepository.Handlers.Commands.UpdateWorkTeamRole
{
    /// <summary>
    /// Команда обновления роли команд.
    /// </summary>
    /// <param name="Id">Идентификатор.</param>
    /// <param name="Title">Наименование.</param>
    /// <param name="Description">Описание.</param>
    public sealed record UpdateWorkTeamRoleCommand(
        int Id,
        string? Title,
        string? Description
    ) : IRequest;
}
