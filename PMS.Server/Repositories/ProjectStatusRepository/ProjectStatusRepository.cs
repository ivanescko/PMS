using Microsoft.EntityFrameworkCore;
using PMS.Model.Context;
using PMS.Model.Entities;
using PMS.Server.DTOs.ProjectStatusDTO.Commands;
using PMS.Server.DTOs.ProjectStatusDTO.Queries;
using PMS.Server.Exceptions;

namespace PMS.Server.Repositories.ProjectStatusRepository
{
    /// <summary>
    /// Репозиторий для работы с сущностью <see cref="ProjectStatus"/>.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    public class ProjectStatusRepository(PmsDbContext context) : IProjectStatusRepository
    {
        private readonly PmsDbContext _context = context;

        /// <inheritdoc/>
        public async Task<List<GetProjectStatusItemResponse>> GetProjectStatusesAsync()
        {
            return await _context.ProjectStatuses
                .Select(ps => new GetProjectStatusItemResponse
                {
                    ProjectStatusID = ps.ProjectStatusID,
                    Title = ps.Title
                })
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<GetProjectStatusResponse> GetProjectStatusByIdAsync(int id)
        {
            if (id <= 0) throw new BadRequestException("ID must be positive");

            var projectStatus = await _context.ProjectStatuses
                .Where(ps => ps.ProjectStatusID == id)
                .Select(ps => new GetProjectStatusResponse
                {
                    ProjectStatusID = ps.ProjectStatusID,
                    Title = ps.Title,
                    Description = ps.Description
                })
                .FirstOrDefaultAsync();

            if (projectStatus == null)
                throw new NotFoundException("ProjectStatus not found");
            else
                return projectStatus;
        }

        /// <inheritdoc/>
        public async Task CreateProjectStatusAsync(CreateProjectStatusRequest request)
        {
            // Проверка уникальности наименования
            if (await _context.ProjectStatuses.AnyAsync(ps => ps.Title == request.Title))
            {
                throw new ConflictException("Статус проекта с таким наименованием уже существует");
            }

            // Создание объекта пользователя
            ProjectStatus projectStatus = new ProjectStatus
            {
                Title = request.Title,
                Description = request.Description,
            };

            await _context.ProjectStatuses.AddAsync(projectStatus);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateProjectStatusAsync(int id, UpdateProjectStatusRequest request)
        {
            var projectStatus = await _context.ProjectStatuses.FindAsync(id);
            if (projectStatus == null)
                throw new NotFoundException("Статус не найден");

            if (request.Title != null)
            {
                if (projectStatus.Title != request.Title &&
                    await _context.ProjectStatuses.AnyAsync(ps => ps.Title == request.Title))
                {
                    throw new ConflictException("Статус с таким наименованием уже существует");
                }
                projectStatus.Title = request.Title;
            }

            if (request.Description != null)
                projectStatus.Description = request.Description;

            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteProjectStatusAsync(int id)
        {
            var projectStatus = await _context.ProjectStatuses.FindAsync(id);
            if (projectStatus == null)
                throw new NotFoundException("Статус не найден");

            _context.ProjectStatuses.Remove(projectStatus);
            await _context.SaveChangesAsync();
        }
    }
}
