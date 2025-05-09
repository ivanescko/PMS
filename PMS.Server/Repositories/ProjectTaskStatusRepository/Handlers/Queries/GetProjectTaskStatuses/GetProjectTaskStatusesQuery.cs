using MediatR;
using PMS.Server.DTOs.ProjectTaskStatusDTO.Queries;

namespace PMS.Server.Repositories.ProjectTaskStatusRepository.Handlers.Queries.GetProjectTaskStatuses
{
    /// <summary>
    /// Запрос на получение списка категорий задач проектов.
    /// </summary>
    public sealed record GetProjectTaskStatusesQuery() : IRequest<List<GetProjectTaskStatusItemResponse>>;
}
