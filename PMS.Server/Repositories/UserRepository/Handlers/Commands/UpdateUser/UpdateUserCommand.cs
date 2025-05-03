using MediatR;

namespace PMS.Server.Repositories.UserRepository.Handlers.Commands.UpdateUser
{
    /// <summary>
    /// Команда обновления пользователя.
    /// </summary>
    /// <param name="Id">Идентификатор.</param>
    /// <param name="Login">Логин.</param>
    /// <param name="Password">Пароль.</param>
    /// <param name="Name">Имя пользователя.</param>
    /// <param name="IsActive">Флаг, указывающий активен ли аккаунт пользователя.</param>
    public sealed record UpdateUserCommand(
        int Id,
        string? Login,
        string? Password,
        string? Name,
        bool? IsActive
    ) : IRequest;
}
