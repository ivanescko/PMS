using MediatR;
using PMS.Server.DTOs.SprintTaskStatusDTO.Queries;

namespace PMS.Server.Repositories.SprintTaskStatusRepository.Handlers.Queries.GetSprintTaskStatuses
{
    /// <summary>
    /// Запрос на получение списка категорий задач спринта.
    /// </summary>
    public sealed record GetSprintTaskStatusesQuery() : IRequest<List<GetSprintTaskStatusItemResponse>>;
}
