using MediatR;
using PMS.Server.DTOs.ProjectTaskStatusDTO.Queries;

namespace PMS.Server.Repositories.ProjectTaskStatusRepository.Handlers.Queries.GetProjectTaskStatus
{
    /// <summary>
    /// Запрос на получение данных статуса задач проекта.
    /// </summary>
    /// <param name="Id">Идентификатор статуса задач проекта.</param>
    public sealed record GetProjectTaskStatusQuery(int Id) : IRequest<GetProjectTaskStatusResponse>;
}
