using MediatR;
using PMS.Server.DTOs.SprintTaskStatusDTO.Queries;

namespace PMS.Server.Repositories.SprintTaskStatusRepository.Handlers.Queries.GetSprintTaskStatus
{
    /// <summary>
    /// Запрос на получение данных статуса задач спринта.
    /// </summary>
    /// <param name="Id">Идентификатор статуса задач спринта.</param>
    public sealed record GetSprintTaskStatusQuery(int Id) : IRequest<GetSprintTaskStatusResponse>;
}
