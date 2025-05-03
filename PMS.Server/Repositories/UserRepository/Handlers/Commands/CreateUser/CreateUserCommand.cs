using MediatR;

namespace PMS.Server.Repositories.UserRepository.Handlers.Commands.CreateUser
{
    /// <summary>
    /// Команда создания нового пользователя.
    /// </summary>
    /// <param name="Login">Логин.</param>
    /// <param name="Password">Пароль.</param>
    /// <param name="Name">Имя пользователя.</param>
    /// <param name="IsActive">Флаг, указывающий активен ли аккаунт пользователя.</param>    

    public sealed record CreateUserCommand(
        string Login,
        string Password,
        string Name,
        bool IsActive
    ) : IRequest;
}
