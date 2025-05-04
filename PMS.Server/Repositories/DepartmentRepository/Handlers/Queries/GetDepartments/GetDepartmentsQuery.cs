using MediatR;
using PMS.Server.DTOs.DepartmentDTO.Queries;

namespace PMS.Server.Repositories.DepartmentRepository.Handlers.Queries.GetDepartments
{
    /// <summary>
    /// Запрос на получение списка отделов.
    /// </summary>
    public sealed record GetDepartmentsQuery() : IRequest<List<GetDepartmentItemResponse>>;
}
