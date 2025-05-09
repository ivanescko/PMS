using Microsoft.EntityFrameworkCore;
using PMS.Model.Context;
using PMS.Model.Entities;
using PMS.Server.DTOs.ProjectTaskCategoryDTO.Commands;
using PMS.Server.DTOs.ProjectTaskCategoryDTO.Queries;
using PMS.Server.Exceptions;

namespace PMS.Server.Repositories.ProjectTaskCategoryRepository
{
    /// <summary>
    /// Репозиторий для работы с сущностью <see cref="ProjectTaskCategory"/>.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    public class ProjectTaskCategoryRepository(PmsDbContext context) : IProjectTaskCategoryRepository
    {
        private readonly PmsDbContext _context = context;

        /// <inheritdoc/>
        public async Task<List<GetProjectTaskCategoryItemResponse>> GetProjectTaskCategoriesAsync()
        {
            return await _context.ProjectTaskCategories
                .Select(pc => new GetProjectTaskCategoryItemResponse
                {
                    ProjectTaskCategoryID = pc.ProjectTaskCategoryID,
                    Title = pc.Title
                })
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<GetProjectTaskCategoryResponse> GetProjectTaskCategoryByIdAsync(int id)
        {
            if (id <= 0) throw new BadRequestException("ID must be positive");

            var ProjectTaskCategory = await _context.ProjectTaskCategories
                .Where(pc => pc.ProjectTaskCategoryID == id)
                .Select(pc => new GetProjectTaskCategoryResponse
                {
                    ProjectTaskCategoryID = pc.ProjectTaskCategoryID,
                    Title = pc.Title,
                    Description = pc.Description
                })
                .FirstOrDefaultAsync();

            if (ProjectTaskCategory == null)
                throw new NotFoundException("ProjectTaskCategory not found");
            else
                return ProjectTaskCategory;
        }

        /// <inheritdoc/>
        public async Task CreateProjectTaskCategoryAsync(CreateProjectTaskCategoryRequest request)
        {
            // Проверка уникальности наименования
            if (await _context.ProjectTaskCategories.AnyAsync(pc => pc.Title == request.Title))
            {
                throw new ConflictException("Категория с таким наименованием уже существует");
            }

            // Создание объекта пользователя
            ProjectTaskCategory ProjectTaskCategory = new ProjectTaskCategory
            {
                Title = request.Title,
                Description = request.Description,
            };

            await _context.ProjectTaskCategories.AddAsync(ProjectTaskCategory);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateProjectTaskCategoryAsync(int id, UpdateProjectTaskCategoryRequest request)
        {
            var ProjectTaskCategory = await _context.ProjectTaskCategories.FindAsync(id);
            if (ProjectTaskCategory == null)
                throw new NotFoundException("Категория не найдена");

            if (request.Title != null)
            {
                if (ProjectTaskCategory.Title != request.Title &&
                    await _context.ProjectTaskCategories.AnyAsync(pc => pc.Title == request.Title))
                {
                    throw new ConflictException("Категория с таким наименованием уже существует");
                }
                ProjectTaskCategory.Title = request.Title;
            }

            if (request.Description != null)
                ProjectTaskCategory.Description = request.Description;

            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteProjectTaskCategoryAsync(int id)
        {
            var ProjectTaskCategory = await _context.ProjectTaskCategories.FindAsync(id);
            if (ProjectTaskCategory == null)
                throw new NotFoundException("Категория не найдена");

            _context.ProjectTaskCategories.Remove(ProjectTaskCategory);
            await _context.SaveChangesAsync();
        }
    }
}
