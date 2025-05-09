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
                .Select(ptc => new GetProjectTaskCategoryItemResponse
                {
                    ProjectTaskCategoryID = ptc.ProjectTaskCategoryID,
                    Title = ptc.Title
                })
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<GetProjectTaskCategoryResponse> GetProjectTaskCategoryByIdAsync(int id)
        {
            if (id <= 0) throw new BadRequestException("ID must be positive");

            var projectTaskCategory = await _context.ProjectTaskCategories
                .Where(ptc => ptc.ProjectTaskCategoryID == id)
                .Select(ptc => new GetProjectTaskCategoryResponse
                {
                    ProjectTaskCategoryID = ptc.ProjectTaskCategoryID,
                    Title = ptc.Title,
                    Description = ptc.Description
                })
                .FirstOrDefaultAsync();

            if (projectTaskCategory == null)
                throw new NotFoundException("ProjectTaskCategory not found");
            else
                return projectTaskCategory;
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
            ProjectTaskCategory projectTaskCategory = new ProjectTaskCategory
            {
                Title = request.Title,
                Description = request.Description,
            };

            await _context.ProjectTaskCategories.AddAsync(projectTaskCategory);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateProjectTaskCategoryAsync(int id, UpdateProjectTaskCategoryRequest request)
        {
            var projectTaskCategory = await _context.ProjectTaskCategories.FindAsync(id);
            if (projectTaskCategory == null)
                throw new NotFoundException("Категория не найдена");

            if (request.Title != null)
            {
                if (projectTaskCategory.Title != request.Title &&
                    await _context.ProjectTaskCategories.AnyAsync(ptc => ptc.Title == request.Title))
                {
                    throw new ConflictException("Категория с таким наименованием уже существует");
                }
                projectTaskCategory.Title = request.Title;
            }

            if (request.Description != null)
                projectTaskCategory.Description = request.Description;

            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteProjectTaskCategoryAsync(int id)
        {
            var projectTaskCategory = await _context.ProjectTaskCategories.FindAsync(id);
            if (projectTaskCategory == null)
                throw new NotFoundException("Категория не найдена");

            _context.ProjectTaskCategories.Remove(projectTaskCategory);
            await _context.SaveChangesAsync();
        }
    }
}
