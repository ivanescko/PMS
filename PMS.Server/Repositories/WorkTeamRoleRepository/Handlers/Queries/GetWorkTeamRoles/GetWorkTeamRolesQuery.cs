using MediatR;
using PMS.Server.DTOs.WorkTeamRoleDTO.Queries;

namespace PMS.Server.Repositories.WorkTeamRoleRepository.Handlers.Queries.GetWorkTeamRoles
{
    /// <summary>
    /// Запрос на получение списка ролей команд.
    /// </summary>
    public sealed record GetWorkTeamRolesQuery() : IRequest<List<GetWorkTeamRoleItemResponse>>;
}
