using Microsoft.EntityFrameworkCore;
using PMS.Model.Context;
using PMS.Model.Entities;
using PMS.Server.DTOs.SprintTaskStatusDTO.Commands;
using PMS.Server.DTOs.SprintTaskStatusDTO.Queries;
using PMS.Server.Exceptions;

namespace PMS.Server.Repositories.SprintTaskStatusRepository
{
    /// <summary>
    /// Репозиторий для работы с сущностью <see cref="SprintTaskStatus"/>.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    public class SprintTaskStatusRepository(PmsDbContext context) : ISprintTaskStatusRepository
    {
        private readonly PmsDbContext _context = context;

        /// <inheritdoc/>
        public async Task<List<GetSprintTaskStatusItemResponse>> GetSprintTaskStatusesAsync()
        {
            return await _context.SprintTaskStatuses
                .Select(sts => new GetSprintTaskStatusItemResponse
                {
                    SprintTaskStatusID = sts.SprintTaskStatusID,
                    Title = sts.Title
                })
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<GetSprintTaskStatusResponse> GetSprintTaskStatusByIdAsync(int id)
        {
            if (id <= 0) throw new BadRequestException("ID must be positive");

            var sprintTaskStatus = await _context.SprintTaskStatuses
                .Where(sts => sts.SprintTaskStatusID == id)
                .Select(sts => new GetSprintTaskStatusResponse
                {
                    SprintTaskStatusID = sts.SprintTaskStatusID,
                    Title = sts.Title
                    //Description = sts.Description
                })
                .FirstOrDefaultAsync();

            if (sprintTaskStatus == null)
                throw new NotFoundException("SprintTaskStatus not found");
            else
                return sprintTaskStatus;
        }

        /// <inheritdoc/>
        public async Task CreateSprintTaskStatusAsync(CreateSprintTaskStatusRequest request)
        {
            // Проверка уникальности наименования
            if (await _context.SprintTaskStatuses.AnyAsync(sts => sts.Title == request.Title))
            {
                throw new ConflictException("Статус задачи спринта с таким наименованием уже существует");
            }

            // Создание объекта спринта
            SprintTaskStatus sprintTaskStatus = new SprintTaskStatus
            {
                Title = request.Title,
                //Description = request.Description,
            };

            await _context.SprintTaskStatuses.AddAsync(sprintTaskStatus);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateSprintTaskStatusAsync(int id, UpdateSprintTaskStatusRequest request)
        {
            var sprintTaskStatus = await _context.SprintTaskStatuses.FindAsync(id);
            if (sprintTaskStatus == null)
                throw new NotFoundException("Статус не найден");

            if (request.Title != null)
            {
                if (sprintTaskStatus.Title != request.Title &&
                    await _context.SprintTaskStatuses.AnyAsync(sts => sts.Title == request.Title))
                {
                    throw new ConflictException("Статус с таким наименованием уже существует");
                }
                sprintTaskStatus.Title = request.Title;
            }

            //if (request.Description != null)
            //    sprintTaskStatus.Description = request.Description;

            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteSprintTaskStatusAsync(int id)
        {
            var sprintTaskStatus = await _context.SprintTaskStatuses.FindAsync(id);
            if (sprintTaskStatus == null)
                throw new NotFoundException("Статус не найден");

            _context.SprintTaskStatuses.Remove(sprintTaskStatus);
            await _context.SaveChangesAsync();
        }
    }
}
