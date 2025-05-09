using MediatR;
using PMS.Server.DTOs.WorkTeamRoleDTO.Queries;

namespace PMS.Server.Repositories.WorkTeamRoleRepository.Handlers.Queries.GetWorkTeamRoles
{
    /// <summary>
    /// Обработчик команды <see cref="GetWorkTeamRolesQuery"/>.
    /// </summary>
    /// <remarks>
    /// Делегирует запрос на получение списка в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IWorkTeamRoleRepository"/>.</param>
    public class GetWorkTeamRolesQueryHandler(IWorkTeamRoleRepository repository) : IRequestHandler<GetWorkTeamRolesQuery, List<GetWorkTeamRoleItemResponse>>
    {
        private readonly IWorkTeamRoleRepository _repository = repository;

        /// <summary>
        /// Метод обработки запроса <see cref="GetWorkTeamRolesQuery"/>.
        /// </summary>
        /// <returns>Список объектов <see cref="GetWorkTeamRoleItemResponse"/>.</returns>
        /// <param name="request">Запрос на получение списка.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task<List<GetWorkTeamRoleItemResponse>> Handle(GetWorkTeamRolesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetWorkTeamRolesAsync();
        }
    }
}
