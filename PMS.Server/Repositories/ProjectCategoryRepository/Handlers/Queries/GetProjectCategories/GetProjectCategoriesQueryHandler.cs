using MediatR;
using PMS.Server.DTOs.ProjectCategoryDTO.Queries;

namespace PMS.Server.Repositories.ProjectCategoryRepository.Handlers.Queries.GetProjectCategories
{
    /// <summary>
    /// Обработчик команды <see cref="GetProjectCategoriesQuery"/>.
    /// </summary>
    /// <remarks>
    /// Делегирует запрос на получение списка в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IProjectCategoryRepository"/>.</param>
    public class GetProjectCategoriesQueryHandler(IProjectCategoryRepository repository) : IRequestHandler<GetProjectCategoriesQuery, List<GetProjectCategoryItemResponse>>
    {
        private readonly IProjectCategoryRepository _repository = repository;

        /// <summary>
        /// Метод обработки запроса <see cref="GetProjectCategoriesQuery"/>.
        /// </summary>
        /// <returns>Список объектов <see cref="GetProjectCategoryItemResponse"/>.</returns>
        /// <param name="request">Запрос на получение списка.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task<List<GetProjectCategoryItemResponse>> Handle(GetProjectCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetProjectCategoriesAsync();
        }
    }
}
