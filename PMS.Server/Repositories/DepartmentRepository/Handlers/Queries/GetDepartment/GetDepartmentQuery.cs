using MediatR;
using PMS.Server.DTOs.DepartmentDTO.Queries;

namespace PMS.Server.Repositories.DepartmentRepository.Handlers.Queries.GetDepartment
{
    /// <summary>
    /// Запрос на получение данных отдела.
    /// </summary>
    /// <param name="Id">Идентификатор отдела.</param>
    public sealed record GetDepartmentQuery(int Id) : IRequest<GetDepartmentResponse>;
}
