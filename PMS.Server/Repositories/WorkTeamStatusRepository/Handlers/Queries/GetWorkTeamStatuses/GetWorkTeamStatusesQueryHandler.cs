using MediatR;
using PMS.Server.DTOs.WorkTeamStatusDTO.Queries;

namespace PMS.Server.Repositories.WorkTeamStatusRepository.Handlers.Queries.GetWorkTeamStatuses
{
    /// <summary>
    /// Обработчик команды <see cref="GetWorkTeamStatusesQuery"/>.
    /// </summary>
    /// <remarks>
    /// Делегирует запрос на получение списка в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IWorkTeamStatusRepository"/>.</param>
    public class GetWorkTeamStatusesQueryHandler(IWorkTeamStatusRepository repository) : IRequestHandler<GetWorkTeamStatusesQuery, List<GetWorkTeamStatusItemResponse>>
    {
        private readonly IWorkTeamStatusRepository _repository = repository;

        /// <summary>
        /// Метод обработки запроса <see cref="GetWorkTeamStatusesQuery"/>.
        /// </summary>
        /// <returns>Список объектов <see cref="GetWorkTeamStatusItemResponse"/>.</returns>
        /// <param name="request">Запрос на получение списка.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task<List<GetWorkTeamStatusItemResponse>> Handle(GetWorkTeamStatusesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetWorkTeamStatusesAsync();
        }
    }
}
