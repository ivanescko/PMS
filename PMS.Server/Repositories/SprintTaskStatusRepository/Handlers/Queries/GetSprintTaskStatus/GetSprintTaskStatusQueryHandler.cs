using MediatR;
using PMS.Server.DTOs.SprintTaskStatusDTO.Queries;

namespace PMS.Server.Repositories.SprintTaskStatusRepository.Handlers.Queries.GetSprintTaskStatus
{
    /// <summary>
    /// Обработчик команды <see cref="GetSprintTaskStatusQuery"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует запрос на получение данных в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="ISprintTaskStatusRepository"/>.</param>
    public class GetSprintTaskStatusQueryHandler(ISprintTaskStatusRepository repository) : IRequestHandler<GetSprintTaskStatusQuery, GetSprintTaskStatusResponse>
    {
        private readonly ISprintTaskStatusRepository _repository = repository;

        /// <summary>
        /// Метод обработки запроса <see cref="GetSprintTaskStatusQuery"/>.
        /// </summary>
        /// <returns>Объект с данными <see cref="GetSprintTaskStatusResponse"/>.</returns>
        /// <param name="request">Запрос на получение данных.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>        
        public async Task<GetSprintTaskStatusResponse> Handle(GetSprintTaskStatusQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetSprintTaskStatusByIdAsync(request.Id);
        }
    }
}
