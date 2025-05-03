using MediatR;
using PMS.Server.DTOs.SpecialityDTO.Queries;

namespace PMS.Server.Repositories.SpecialityRepository.Handlers.Queries.GetSpecialities
{
    /// <summary>
    /// Запрос на получение списка специальностей.
    /// </summary>
    public sealed record GetSpecialitiesQuery() : IRequest<List<GetSpecialityItemResponse>>;
}
