using Microsoft.EntityFrameworkCore;
using PMS.Model.Context;
using PMS.Model.Entities;
using PMS.Server.DTOs.ProjectTaskStatusDTO.Commands;
using PMS.Server.DTOs.ProjectTaskStatusDTO.Queries;
using PMS.Server.Exceptions;

namespace PMS.Server.Repositories.ProjectTaskStatusRepository
{
    /// <summary>
    /// Репозиторий для работы с сущностью <see cref="ProjectTaskStatus"/>.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    public class ProjectTaskStatusRepository(PmsDbContext context) : IProjectTaskStatusRepository
    {
        private readonly PmsDbContext _context = context;

        /// <inheritdoc/>
        public async Task<List<GetProjectTaskStatusItemResponse>> GetProjectTaskStatusesAsync()
        {
            return await _context.ProjectTaskStatuses
                .Select(pts => new GetProjectTaskStatusItemResponse
                {
                    ProjectTaskStatusID = pts.ProjectTaskStatusID,
                    Title = pts.Title
                })
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<GetProjectTaskStatusResponse> GetProjectTaskStatusByIdAsync(int id)
        {
            if (id <= 0) throw new BadRequestException("ID must be positive");

            var projectTaskStatus = await _context.ProjectTaskStatuses
                .Where(pts => pts.ProjectTaskStatusID == id)
                .Select(pts => new GetProjectTaskStatusResponse
                {
                    ProjectTaskStatusID = pts.ProjectTaskStatusID,
                    Title = pts.Title,
                    Description = pts.Description
                })
                .FirstOrDefaultAsync();

            if (projectTaskStatus == null)
                throw new NotFoundException("ProjectTaskStatus not found");
            else
                return projectTaskStatus;
        }

        /// <inheritdoc/>
        public async Task CreateProjectTaskStatusAsync(CreateProjectTaskStatusRequest request)
        {
            // Проверка уникальности наименования
            if (await _context.ProjectTaskStatuses.AnyAsync(pts => pts.Title == request.Title))
            {
                throw new ConflictException("Статус проекта с таким наименованием уже существует");
            }

            // Создание объекта пользователя
            ProjectTaskStatus projectTaskStatus = new ProjectTaskStatus
            {
                Title = request.Title,
                Description = request.Description,
            };

            await _context.ProjectTaskStatuses.AddAsync(projectTaskStatus);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateProjectTaskStatusAsync(int id, UpdateProjectTaskStatusRequest request)
        {
            var projectTaskStatus = await _context.ProjectTaskStatuses.FindAsync(id);
            if (projectTaskStatus == null)
                throw new NotFoundException("Статус не найден");

            if (request.Title != null)
            {
                if (projectTaskStatus.Title != request.Title &&
                    await _context.ProjectTaskStatuses.AnyAsync(pts => pts.Title == request.Title))
                {
                    throw new ConflictException("Статус с таким наименованием уже существует");
                }
                projectTaskStatus.Title = request.Title;
            }

            if (request.Description != null)
                projectTaskStatus.Description = request.Description;

            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteProjectTaskStatusAsync(int id)
        {
            var projectTaskStatus = await _context.ProjectTaskStatuses.FindAsync(id);
            if (projectTaskStatus == null)
                throw new NotFoundException("Статус не найден");

            _context.ProjectTaskStatuses.Remove(projectTaskStatus);
            await _context.SaveChangesAsync();
        }
    }
}
