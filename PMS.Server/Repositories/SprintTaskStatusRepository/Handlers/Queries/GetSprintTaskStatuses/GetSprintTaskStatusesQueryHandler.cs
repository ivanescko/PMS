using MediatR;
using PMS.Server.DTOs.SprintTaskStatusDTO.Queries;

namespace PMS.Server.Repositories.SprintTaskStatusRepository.Handlers.Queries.GetSprintTaskStatuses
{
    /// <summary>
    /// Обработчик команды <see cref="GetSprintTaskStatusesQuery"/>.
    /// </summary>
    /// <remarks>
    /// Делегирует запрос на получение списка в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="ISprintTaskStatusRepository"/>.</param>
    public class GetSprintTaskStatusesQueryHandler(ISprintTaskStatusRepository repository) : IRequestHandler<GetSprintTaskStatusesQuery, List<GetSprintTaskStatusItemResponse>>
    {
        private readonly ISprintTaskStatusRepository _repository = repository;

        /// <summary>
        /// Метод обработки запроса <see cref="GetSprintTaskStatusesQuery"/>.
        /// </summary>
        /// <returns>Список объектов <see cref="GetSprintTaskStatusItemResponse"/>.</returns>
        /// <param name="request">Запрос на получение списка.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task<List<GetSprintTaskStatusItemResponse>> Handle(GetSprintTaskStatusesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetSprintTaskStatusesAsync();
        }
    }
}
