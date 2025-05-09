using Microsoft.EntityFrameworkCore;
using PMS.Model.Context;
using PMS.Model.Entities;
using PMS.Server.DTOs.WorkTeamStatusDTO.Commands;
using PMS.Server.DTOs.WorkTeamStatusDTO.Queries;
using PMS.Server.Exceptions;

namespace PMS.Server.Repositories.WorkTeamStatusRepository
{
    /// <summary>
    /// Репозиторий для работы с сущностью <see cref="WorkTeamStatus"/>.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    public class WorkTeamStatusRepository(PmsDbContext context) : IWorkTeamStatusRepository
    {
        private readonly PmsDbContext _context = context;

        /// <inheritdoc/>
        public async Task<List<GetWorkTeamStatusItemResponse>> GetWorkTeamStatusesAsync()
        {
            return await _context.WorkTeamStatuses
                .Select(wts => new GetWorkTeamStatusItemResponse
                {
                    WorkTeamStatusID = wts.WorkTeamStatusID,
                    Title = wts.Title
                })
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<GetWorkTeamStatusResponse> GetWorkTeamStatusByIdAsync(int id)
        {
            if (id <= 0) throw new BadRequestException("ID must be positive");

            var workTeamStatus = await _context.WorkTeamStatuses
                .Where(wts => wts.WorkTeamStatusID == id)
                .Select(wts => new GetWorkTeamStatusResponse
                {
                    WorkTeamStatusID = wts.WorkTeamStatusID,
                    Title = wts.Title,
                    Description = wts.Description
                })
                .FirstOrDefaultAsync();

            if (workTeamStatus == null)
                throw new NotFoundException("WorkTeamStatus not found");
            else
                return workTeamStatus;
        }

        /// <inheritdoc/>
        public async Task CreateWorkTeamStatusAsync(CreateWorkTeamStatusRequest request)
        {
            // Проверка уникальности наименования
            if (await _context.WorkTeamStatuses.AnyAsync(wts => wts.Title == request.Title))
            {
                throw new ConflictException("Статус проекта с таким наименованием уже существует");
            }

            // Создание объекта пользователя
            WorkTeamStatus workTeamStatus = new WorkTeamStatus
            {
                Title = request.Title,
                Description = request.Description,
            };

            await _context.WorkTeamStatuses.AddAsync(workTeamStatus);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateWorkTeamStatusAsync(int id, UpdateWorkTeamStatusRequest request)
        {
            var workTeamStatus = await _context.WorkTeamStatuses.FindAsync(id);
            if (workTeamStatus == null)
                throw new NotFoundException("Статус не найден");

            if (request.Title != null)
            {
                if (workTeamStatus.Title != request.Title &&
                    await _context.WorkTeamStatuses.AnyAsync(wts => wts.Title == request.Title))
                {
                    throw new ConflictException("Статус с таким наименованием уже существует");
                }
                workTeamStatus.Title = request.Title;
            }

            if (request.Description != null)
                workTeamStatus.Description = request.Description;

            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteWorkTeamStatusAsync(int id)
        {
            var workTeamStatus = await _context.WorkTeamStatuses.FindAsync(id);
            if (workTeamStatus == null)
                throw new NotFoundException("Статус не найден");

            _context.WorkTeamStatuses.Remove(workTeamStatus);
            await _context.SaveChangesAsync();
        }
    }
}
