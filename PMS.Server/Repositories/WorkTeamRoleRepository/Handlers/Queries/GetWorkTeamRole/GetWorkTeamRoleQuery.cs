using MediatR;
using PMS.Server.DTOs.WorkTeamRoleDTO.Queries;

namespace PMS.Server.Repositories.WorkTeamRoleRepository.Handlers.Queries.GetWorkTeamRole
{
    /// <summary>
    /// Запрос на получение данных роли команд.
    /// </summary>
    /// <param name="Id">Идентификатор роли команд.</param>
    public sealed record GetWorkTeamRoleQuery(int Id) : IRequest<GetWorkTeamRoleResponse>;
}
