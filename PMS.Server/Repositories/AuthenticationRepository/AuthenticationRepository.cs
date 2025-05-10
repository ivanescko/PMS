using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PMS.Model.Context;
using PMS.Server.Exceptions;
using PMS.Server.Repositories.AuthenticationRepository.Handlers.Commands;

namespace PMS.Server.Repositories.AuthenticationRepository
{
    public class AuthenticationRepository(PmsDbContext context, IConfiguration configuration) : IAuthenticationRepository
    {
        private readonly PmsDbContext _context = context;
        private readonly IConfiguration _configuration = configuration;

        public async Task<string> LoginAsync(LoginCommand command)
        {
            var user = await _context.Users
                .Where(u => u.Login == command.Login)
                .FirstOrDefaultAsync();

            if (user == null) throw new NotFoundException("User not found");

            if (user.Password == command.Password)
                return GenerateJwtToken(command.Login);
            else
                throw new BadRequestException("Невалидный пароль");
        }

        private string GenerateJwtToken(string login)
        {
            //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                expires: DateTime.Now.AddHours(3),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)),
                    SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
