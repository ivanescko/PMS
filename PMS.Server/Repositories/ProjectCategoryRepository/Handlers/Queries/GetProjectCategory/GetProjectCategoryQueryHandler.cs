using MediatR;
using PMS.Server.DTOs.ProjectCategoryDTO.Queries;

namespace PMS.Server.Repositories.ProjectCategoryRepository.Handlers.Queries.GetProjectCategory
{
    /// <summary>
    /// Обработчик команды <see cref="GetProjectCategoryQuery"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует запрос на получение данных в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IProjectCategoryRepository"/>.</param>
    public class GetProjectCategoryQueryHandler(IProjectCategoryRepository repository) : IRequestHandler<GetProjectCategoryQuery, GetProjectCategoryResponse>
    {
        private readonly IProjectCategoryRepository _repository = repository;

        /// <summary>
        /// Метод обработки запроса <see cref="GetProjectCategoryQuery"/>.
        /// </summary>
        /// <returns>Объект с данными <see cref="GetProjectCategoryResponse"/>.</returns>
        /// <param name="request">Запрос на получение данных.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>        
        public async Task<GetProjectCategoryResponse> Handle(GetProjectCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetProjectCategoryByIdAsync(request.Id);
        }
    }
}
