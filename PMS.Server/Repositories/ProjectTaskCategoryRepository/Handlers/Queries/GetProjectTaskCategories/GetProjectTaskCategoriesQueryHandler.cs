using MediatR;
using PMS.Server.DTOs.ProjectTaskCategoryDTO.Queries;

namespace PMS.Server.Repositories.ProjectTaskCategoryRepository.Handlers.Queries.GetProjectTaskCategories
{
    /// <summary>
    /// Обработчик команды <see cref="GetProjectTaskCategoriesQuery"/>.
    /// </summary>
    /// <remarks>
    /// Делегирует запрос на получение списка в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IProjectTaskCategoryRepository"/>.</param>
    public class GetProjectTaskCategoriesQueryHandler(IProjectTaskCategoryRepository repository) : IRequestHandler<GetProjectTaskCategoriesQuery, List<GetProjectTaskCategoryItemResponse>>
    {
        private readonly IProjectTaskCategoryRepository _repository = repository;

        /// <summary>
        /// Метод обработки запроса <see cref="GetProjectTaskCategoriesQuery"/>.
        /// </summary>
        /// <returns>Список объектов <see cref="GetProjectTaskCategoryItemResponse"/>.</returns>
        /// <param name="request">Запрос на получение списка.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task<List<GetProjectTaskCategoryItemResponse>> Handle(GetProjectTaskCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetProjectTaskCategoriesAsync();
        }
    }
}
