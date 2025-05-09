using MediatR;
using PMS.Server.DTOs.ProjectStatusDTO.Queries;

namespace PMS.Server.Repositories.ProjectStatusRepository.Handlers.Queries.GetProjectStatus
{
    /// <summary>
    /// Обработчик команды <see cref="GetProjectStatusQuery"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует запрос на получение данных в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IProjectStatusRepository"/>.</param>
    public class GetProjectStatusQueryHandler(IProjectStatusRepository repository) : IRequestHandler<GetProjectStatusQuery, GetProjectStatusResponse>
    {
        private readonly IProjectStatusRepository _repository = repository;

        /// <summary>
        /// Метод обработки запроса <see cref="GetProjectStatusQuery"/>.
        /// </summary>
        /// <returns>Объект с данными <see cref="GetProjectStatusResponse"/>.</returns>
        /// <param name="request">Запрос на получение данных.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>        
        public async Task<GetProjectStatusResponse> Handle(GetProjectStatusQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetProjectStatusByIdAsync(request.Id);
        }
    }
}
