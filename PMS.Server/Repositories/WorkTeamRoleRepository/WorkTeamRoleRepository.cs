using Microsoft.EntityFrameworkCore;
using PMS.Model.Context;
using PMS.Model.Entities;
using PMS.Server.DTOs.WorkTeamRoleDTO.Commands;
using PMS.Server.DTOs.WorkTeamRoleDTO.Queries;
using PMS.Server.Exceptions;

namespace PMS.Server.Repositories.WorkTeamRoleRepository
{
    /// <summary>
    /// Репозиторий для работы с сущностью <see cref="WorkTeamRole"/>.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    public class WorkTeamRoleRepository(PmsDbContext context) : IWorkTeamRoleRepository
    {
        private readonly PmsDbContext _context = context;

        /// <inheritdoc/>
        public async Task<List<GetWorkTeamRoleItemResponse>> GetWorkTeamRolesAsync()
        {
            return await _context.WorkTeamRoles
                .Select(wtr => new GetWorkTeamRoleItemResponse
                {
                    WorkTeamRoleID = wtr.WorkTeamRoleID,
                    Title = wtr.Title
                })
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<GetWorkTeamRoleResponse> GetWorkTeamRoleByIdAsync(int id)
        {
            if (id <= 0) throw new BadRequestException("ID must be positive");

            var workTeamRole = await _context.WorkTeamRoles
                .Where(wtr => wtr.WorkTeamRoleID == id)
                .Select(wtr => new GetWorkTeamRoleResponse
                {
                    WorkTeamRoleID = wtr.WorkTeamRoleID,
                    Title = wtr.Title,
                    Description = wtr.Description
                })
                .FirstOrDefaultAsync();

            if (workTeamRole == null)
                throw new NotFoundException("WorkTeamRole not found");
            else
                return workTeamRole;
        }

        /// <inheritdoc/>
        public async Task CreateWorkTeamRoleAsync(CreateWorkTeamRoleRequest request)
        {
            // Проверка уникальности наименования
            if (await _context.WorkTeamRoles.AnyAsync(wtr => wtr.Title == request.Title))
            {
                throw new ConflictException("Роли команды с таким наименованием уже существует");
            }

            // Создание объекта пользователя
            WorkTeamRole workTeamRole = new WorkTeamRole
            {
                Title = request.Title,
                Description = request.Description,
            };

            await _context.WorkTeamRoles.AddAsync(workTeamRole);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateWorkTeamRoleAsync(int id, UpdateWorkTeamRoleRequest request)
        {
            var workTeamRole = await _context.WorkTeamRoles.FindAsync(id);
            if (workTeamRole == null)
                throw new NotFoundException("Роль не найдена");

            if (request.Title != null)
            {
                if (workTeamRole.Title != request.Title &&
                    await _context.WorkTeamRoles.AnyAsync(wtr => wtr.Title == request.Title))
                {
                    throw new ConflictException("Роли с таким наименованием уже существует");
                }
                workTeamRole.Title = request.Title;
            }

            if (request.Description != null)
                workTeamRole.Description = request.Description;

            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteWorkTeamRoleAsync(int id)
        {
            var workTeamRole = await _context.WorkTeamRoles.FindAsync(id);
            if (workTeamRole == null)
                throw new NotFoundException("Роли не найдена");

            _context.WorkTeamRoles.Remove(workTeamRole);
            await _context.SaveChangesAsync();
        }
    }
}
