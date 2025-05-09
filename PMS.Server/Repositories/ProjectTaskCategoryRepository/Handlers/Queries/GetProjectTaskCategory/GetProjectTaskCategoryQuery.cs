using MediatR;
using PMS.Server.DTOs.ProjectTaskCategoryDTO.Queries;

namespace PMS.Server.Repositories.ProjectTaskCategoryRepository.Handlers.Queries.GetProjectTaskCategory
{
    /// <summary>
    /// Запрос на получение данных категории задач проекта.
    /// </summary>
    /// <param name="Id">Идентификатор категории задач проекта.</param>
    public sealed record GetProjectTaskCategoryQuery(int Id) : IRequest<GetProjectTaskCategoryResponse>;
}
