using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PMS.Model.Context;
using PMS.Model.Entities;
using PMS.Server.DTOs.UserDTO.Commands;
using PMS.Server.DTOs.UserDTO.Queries;
using PMS.Server.Exceptions;
using PMS.Server.Repositories.UserRepository.Handlers.Commands.UpdateUser;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PMS.Server.Repositories.UserRepository
{
    /// <summary>
    /// Репозиторий для работы с пользователями.
    /// </summary>
    /// <remarks>
    /// Включает в себя методы взаимодействия с сущнсотью <see cref="User"/>.
    /// </remarks>
    /// <param name="context">Контекст базы данных.</param>
    public class UserRepository(PmsDbContext context) : IUserRepository
    {
        private readonly PmsDbContext _context = context;

        /// <inheritdoc/>
        public async Task<List<GetUsersItemResponse>> GetUsersAsync()
        {
            return await _context.Users
                .Select(u => new GetUsersItemResponse
                {
                    UserID = u.UserID,
                    Name = u.Name,
                })
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<GetUserResponse> GetUserByIdAsync(int id)
        {
            if (id <= 0) throw new BadRequestException("ID must be positive");

            var user = await _context.Users
                .Where(u => u.UserID == id)
                .Select(u => new GetUserResponse
                {
                    UserID = u.UserID,
                    Login = u.Login,
                    Name = u.Name,
                    LastLoginDate = u.LastLoginDate,
                    IsActive = u.IsActive
                })
                .FirstOrDefaultAsync();

            if (user == null)
                throw new NotFoundException("User not found");
            else
                return user;
        }

        /// <inheritdoc/>
        public async Task CreateUserAsync(CreateUserRequest createUserDto)
        {
            // Проверка уникальности логина
            if (await _context.Users.AnyAsync(u => u.Login == createUserDto.Login))
            {
                throw new ConflictException("Пользователь с таким логином уже существует");
            }

            // Создание объекта пользователя
            User newUser = new User
            {
                Login = createUserDto.Login,
                Password = createUserDto.Password,
                Name = createUserDto.Name,
                IsActive = createUserDto.IsActive,
                LastLoginDate = null
            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateUserAsync(int id, UpdateUserRequest request)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                throw new NotFoundException("Пользователь не найден");

            

            if (request.Login != null)
            {
                if (user.Login != request.Login &&
                    await _context.Users.AnyAsync(u => u.Login == request.Login))
                {
                    throw new ConflictException("Пользователь с таким логином уже существует");
                }
                user.Login = request.Login;
            }

            if (request.Password != null)
                user.Password = request.Password;

            if (request.Name != null)
                user.Name = request.Name;

            if (request.IsActive.HasValue)
                user.IsActive = request.IsActive.Value;

            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                throw new NotFoundException("Пользователь не найден");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
