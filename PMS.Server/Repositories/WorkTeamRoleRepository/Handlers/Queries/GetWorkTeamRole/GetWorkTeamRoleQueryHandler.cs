using MediatR;
using PMS.Server.DTOs.WorkTeamRoleDTO.Queries;

namespace PMS.Server.Repositories.WorkTeamRoleRepository.Handlers.Queries.GetWorkTeamRole
{
    /// <summary>
    /// Обработчик команды <see cref="GetWorkTeamRoleQuery"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует запрос на получение данных в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IWorkTeamRoleRepository"/>.</param>
    public class GetWorkTeamRoleQueryHandler(IWorkTeamRoleRepository repository) : IRequestHandler<GetWorkTeamRoleQuery, GetWorkTeamRoleResponse>
    {
        private readonly IWorkTeamRoleRepository _repository = repository;

        /// <summary>
        /// Метод обработки запроса <see cref="GetWorkTeamRoleQuery"/>.
        /// </summary>
        /// <returns>Объект с данными <see cref="GetWorkTeamRoleResponse"/>.</returns>
        /// <param name="request">Запрос на получение данных.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>        
        public async Task<GetWorkTeamRoleResponse> Handle(GetWorkTeamRoleQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetWorkTeamRoleByIdAsync(request.Id);
        }
    }
}
