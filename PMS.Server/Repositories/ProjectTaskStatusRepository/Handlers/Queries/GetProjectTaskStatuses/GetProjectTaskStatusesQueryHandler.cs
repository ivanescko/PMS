using MediatR;
using PMS.Server.DTOs.ProjectTaskStatusDTO.Queries;

namespace PMS.Server.Repositories.ProjectTaskStatusRepository.Handlers.Queries.GetProjectTaskStatuses
{
    /// <summary>
    /// Обработчик команды <see cref="GetProjectTaskStatusesQuery"/>.
    /// </summary>
    /// <remarks>
    /// Делегирует запрос на получение списка в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IProjectTaskStatusRepository"/>.</param>
    public class GetProjectTaskStatusesQueryHandler(IProjectTaskStatusRepository repository) : IRequestHandler<GetProjectTaskStatusesQuery, List<GetProjectTaskStatusItemResponse>>
    {
        private readonly IProjectTaskStatusRepository _repository = repository;

        /// <summary>
        /// Метод обработки запроса <see cref="GetProjectTaskStatusesQuery"/>.
        /// </summary>
        /// <returns>Список объектов <see cref="GetProjectTaskStatusItemResponse"/>.</returns>
        /// <param name="request">Запрос на получение списка.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task<List<GetProjectTaskStatusItemResponse>> Handle(GetProjectTaskStatusesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetProjectTaskStatusesAsync();
        }
    }
}
