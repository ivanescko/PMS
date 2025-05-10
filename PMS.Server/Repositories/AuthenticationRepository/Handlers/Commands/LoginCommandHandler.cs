using MediatR;

namespace PMS.Server.Repositories.AuthenticationRepository.Handlers.Commands
{
    public class LoginCommandHandler(IAuthenticationRepository repository) : IRequestHandler<LoginCommand, string>
    {
        private readonly IAuthenticationRepository _repository = repository;

        public async Task<string> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            return await _repository.LoginAsync(command);
        }
    }
}
