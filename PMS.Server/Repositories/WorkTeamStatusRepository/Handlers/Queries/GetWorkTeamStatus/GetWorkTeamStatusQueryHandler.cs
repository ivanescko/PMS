using MediatR;
using PMS.Server.DTOs.WorkTeamStatusDTO.Queries;

namespace PMS.Server.Repositories.WorkTeamStatusRepository.Handlers.Queries.GetWorkTeamStatus
{
    /// <summary>
    /// Обработчик команды <see cref="GetWorkTeamStatusQuery"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует запрос на получение данных в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IWorkTeamStatusRepository"/>.</param>
    public class GetWorkTeamStatusQueryHandler(IWorkTeamStatusRepository repository) : IRequestHandler<GetWorkTeamStatusQuery, GetWorkTeamStatusResponse>
    {
        private readonly IWorkTeamStatusRepository _repository = repository;

        /// <summary>
        /// Метод обработки запроса <see cref="GetWorkTeamStatusQuery"/>.
        /// </summary>
        /// <returns>Объект с данными <see cref="GetWorkTeamStatusResponse"/>.</returns>
        /// <param name="request">Запрос на получение данных.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>        
        public async Task<GetWorkTeamStatusResponse> Handle(GetWorkTeamStatusQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetWorkTeamStatusByIdAsync(request.Id);
        }
    }
}
