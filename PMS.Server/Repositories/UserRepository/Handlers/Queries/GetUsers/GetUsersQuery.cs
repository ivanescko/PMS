using MediatR;
using PMS.Server.DTOs.UserDTO.Queries;

namespace PMS.Server.Repositories.UserRepository.Handlers.Queries.GetUsers
{
    /// <summary>
    /// Запрос на получение списка пользователей.
    /// </summary>
    public sealed record GetUsersQuery() : IRequest<List<GetUserItemResponse>>;
}
