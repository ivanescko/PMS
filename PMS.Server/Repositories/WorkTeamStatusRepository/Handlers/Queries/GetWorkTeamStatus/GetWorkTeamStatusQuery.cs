using MediatR;
using PMS.Server.DTOs.WorkTeamStatusDTO.Queries;

namespace PMS.Server.Repositories.WorkTeamStatusRepository.Handlers.Queries.GetWorkTeamStatus
{
    /// <summary>
    /// Запрос на получение данных статуса команд.
    /// </summary>
    /// <param name="Id">Идентификатор статуса команд.</param>
    public sealed record GetWorkTeamStatusQuery(int Id) : IRequest<GetWorkTeamStatusResponse>;
}
