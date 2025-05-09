using MediatR;
using PMS.Server.DTOs.ProjectTaskCategoryDTO.Queries;

namespace PMS.Server.Repositories.ProjectTaskCategoryRepository.Handlers.Queries.GetProjectTaskCategory
{
    /// <summary>
    /// Обработчик команды <see cref="GetProjectTaskCategoryQuery"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует запрос на получение данных в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IProjectTaskCategoryRepository"/>.</param>
    public class GetProjectTaskCategoryQueryHandler(IProjectTaskCategoryRepository repository) : IRequestHandler<GetProjectTaskCategoryQuery, GetProjectTaskCategoryResponse>
    {
        private readonly IProjectTaskCategoryRepository _repository = repository;

        /// <summary>
        /// Метод обработки запроса <see cref="GetProjectTaskCategoryQuery"/>.
        /// </summary>
        /// <returns>Объект с данными <see cref="GetProjectTaskCategoryResponse"/>.</returns>
        /// <param name="request">Запрос на получение данных.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>        
        public async Task<GetProjectTaskCategoryResponse> Handle(GetProjectTaskCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetProjectTaskCategoryByIdAsync(request.Id);
        }
    }
}
