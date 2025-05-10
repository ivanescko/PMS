using PMS.Server.Repositories.AuthenticationRepository.Handlers.Commands;

namespace PMS.Server.Repositories.AuthenticationRepository
{
    public interface IAuthenticationRepository
    {
        Task<string> LoginAsync(LoginCommand command);
    }
}
