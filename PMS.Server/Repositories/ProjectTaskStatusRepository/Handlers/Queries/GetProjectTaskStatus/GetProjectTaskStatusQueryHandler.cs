using MediatR;
using PMS.Server.DTOs.ProjectTaskStatusDTO.Queries;

namespace PMS.Server.Repositories.ProjectTaskStatusRepository.Handlers.Queries.GetProjectTaskStatus
{
    /// <summary>
    /// Обработчик команды <see cref="GetProjectTaskStatusQuery"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует запрос на получение данных в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IProjectTaskStatusRepository"/>.</param>
    public class GetProjectTaskStatusQueryHandler(IProjectTaskStatusRepository repository) : IRequestHandler<GetProjectTaskStatusQuery, GetProjectTaskStatusResponse>
    {
        private readonly IProjectTaskStatusRepository _repository = repository;

        /// <summary>
        /// Метод обработки запроса <see cref="GetProjectTaskStatusQuery"/>.
        /// </summary>
        /// <returns>Объект с данными <see cref="GetProjectTaskStatusResponse"/>.</returns>
        /// <param name="request">Запрос на получение данных.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>        
        public async Task<GetProjectTaskStatusResponse> Handle(GetProjectTaskStatusQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetProjectTaskStatusByIdAsync(request.Id);
        }
    }
}
