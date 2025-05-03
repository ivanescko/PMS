using MediatR;
using PMS.Server.DTOs.UserDTO.Queries;

namespace PMS.Server.Repositories.UserRepository.Handlers.Queries.GetUser
{
    /// <summary>
    /// Запрос на получение данных пользователя.
    /// </summary>
    /// <param name="Id">Идентификатор пользователя.</param>
    public sealed record GetUserQuery (int Id) : IRequest<GetUserResponse>;
}
