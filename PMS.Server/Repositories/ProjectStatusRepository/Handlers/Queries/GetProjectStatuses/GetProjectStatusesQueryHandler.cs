using MediatR;
using PMS.Server.DTOs.ProjectStatusDTO.Queries;

namespace PMS.Server.Repositories.ProjectStatusRepository.Handlers.Queries.GetProjectStatuses
{
    /// <summary>
    /// Обработчик команды <see cref="GetProjectStatusesQuery"/>.
    /// </summary>
    /// <remarks>
    /// Делегирует запрос на получение списка в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IProjectStatusRepository"/>.</param>
    public class GetProjectStatusesQueryHandler(IProjectStatusRepository repository) : IRequestHandler<GetProjectStatusesQuery, List<GetProjectStatusItemResponse>>
    {
        private readonly IProjectStatusRepository _repository = repository;

        /// <summary>
        /// Метод обработки запроса <see cref="GetProjectStatusesQuery"/>.
        /// </summary>
        /// <returns>Список объектов <see cref="GetProjectStatusItemResponse"/>.</returns>
        /// <param name="request">Запрос на получение списка.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task<List<GetProjectStatusItemResponse>> Handle(GetProjectStatusesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetProjectStatusesAsync();
        }
    }
}
