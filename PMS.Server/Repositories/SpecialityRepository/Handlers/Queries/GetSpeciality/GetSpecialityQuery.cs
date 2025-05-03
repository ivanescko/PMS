using MediatR;
using PMS.Server.DTOs.SpecialityDTO.Queries;

namespace PMS.Server.Repositories.SpecialityRepository.Handlers.Queries.GetSpeciality
{
    /// <summary>
    /// Запрос на получение данных специальности.
    /// </summary>
    /// <param name="Id">Идентификатор специальности.</param>
    public sealed record GetSpecialityQuery(int Id) : IRequest<GetSpecialityResponse>;
}
