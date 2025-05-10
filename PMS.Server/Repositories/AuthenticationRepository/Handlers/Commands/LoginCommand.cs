using MediatR;

namespace PMS.Server.Repositories.AuthenticationRepository.Handlers.Commands
{
    public sealed record LoginCommand(string Login, string Password) : IRequest<string>;
}
