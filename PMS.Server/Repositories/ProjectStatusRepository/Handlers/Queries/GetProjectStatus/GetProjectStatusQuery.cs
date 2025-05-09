using MediatR;
using PMS.Server.DTOs.ProjectStatusDTO.Queries;

namespace PMS.Server.Repositories.ProjectStatusRepository.Handlers.Queries.GetProjectStatus
{
    /// <summary>
    /// Запрос на получение данных статуса проекта.
    /// </summary>
    /// <param name="Id">Идентификатор статуса проекта.</param>
    public sealed record GetProjectStatusQuery(int Id) : IRequest<GetProjectStatusResponse>;
}
