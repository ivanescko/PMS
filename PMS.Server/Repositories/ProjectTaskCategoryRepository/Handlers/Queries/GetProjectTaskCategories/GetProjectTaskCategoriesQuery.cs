using MediatR;
using PMS.Server.DTOs.ProjectTaskCategoryDTO.Queries;

namespace PMS.Server.Repositories.ProjectTaskCategoryRepository.Handlers.Queries.GetProjectTaskCategories
{
    /// <summary>
    /// Запрос на получение списка категорий задач проектов.
    /// </summary>
    public sealed record GetProjectTaskCategoriesQuery() : IRequest<List<GetProjectTaskCategoryItemResponse>>;
}
