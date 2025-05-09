using MediatR;
using PMS.Server.DTOs.WorkTeamStatusDTO.Queries;

namespace PMS.Server.Repositories.WorkTeamStatusRepository.Handlers.Queries.GetWorkTeamStatuses
{
    /// <summary>
    /// Запрос на получение списка категорий команд.
    /// </summary>
    public sealed record GetWorkTeamStatusesQuery() : IRequest<List<GetWorkTeamStatusItemResponse>>;
}
