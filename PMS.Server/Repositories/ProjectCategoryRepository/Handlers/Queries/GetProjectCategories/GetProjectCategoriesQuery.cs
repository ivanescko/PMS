using MediatR;
using PMS.Server.DTOs.ProjectCategoryDTO.Queries;

namespace PMS.Server.Repositories.ProjectCategoryRepository.Handlers.Queries.GetProjectCategories
{
    /// <summary>
    /// Запрос на получение списка категорий проектов.
    /// </summary>
    public sealed record GetProjectCategoriesQuery() : IRequest<List<GetProjectCategoryItemResponse>>;
}
