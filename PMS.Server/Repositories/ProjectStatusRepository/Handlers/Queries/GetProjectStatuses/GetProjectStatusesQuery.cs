using MediatR;
using PMS.Server.DTOs.ProjectStatusDTO.Queries;

namespace PMS.Server.Repositories.ProjectStatusRepository.Handlers.Queries.GetProjectStatuses
{
    /// <summary>
    /// Запрос на получение списка категорий проектов.
    /// </summary>
    public sealed record GetProjectStatusesQuery() : IRequest<List<GetProjectStatusItemResponse>>;
}
