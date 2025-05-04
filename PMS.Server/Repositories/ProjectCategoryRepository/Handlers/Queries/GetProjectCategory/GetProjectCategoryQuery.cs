using MediatR;
using PMS.Server.DTOs.ProjectCategoryDTO.Queries;

namespace PMS.Server.Repositories.ProjectCategoryRepository.Handlers.Queries.GetProjectCategory
{
    /// <summary>
    /// Запрос на получение данных категории проекта.
    /// </summary>
    /// <param name="Id">Идентификатор категории проекта.</param>
    public sealed record GetProjectCategoryQuery(int Id) : IRequest<GetProjectCategoryResponse>;
}
