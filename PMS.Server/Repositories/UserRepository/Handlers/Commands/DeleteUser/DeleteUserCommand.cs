using MediatR;

namespace PMS.Server.Repositories.UserRepository.Handlers.Commands.DeleteUser
{
    /// <summary>
    /// Команда удаления пользователя.
    /// </summary>
    /// <param name="Id">Идентификатор пользователя</param>
    public sealed record DeleteUserCommand(
        int Id
    ) : IRequest;
}
