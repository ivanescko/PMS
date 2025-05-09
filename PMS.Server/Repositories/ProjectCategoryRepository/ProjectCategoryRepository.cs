using Microsoft.EntityFrameworkCore;
using PMS.Model.Context;
using PMS.Model.Entities;
using PMS.Server.DTOs.ProjectCategoryDTO.Commands;
using PMS.Server.DTOs.ProjectCategoryDTO.Queries;
using PMS.Server.Exceptions;

namespace PMS.Server.Repositories.ProjectCategoryRepository
{
    /// <summary>
    /// Репозиторий для работы с сущностью <see cref="ProjectCategory"/>.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    public class ProjectCategoryRepository(PmsDbContext context) : IProjectCategoryRepository
    {
        private readonly PmsDbContext _context = context;

        /// <inheritdoc/>
        public async Task<List<GetProjectCategoryItemResponse>> GetProjectCategoriesAsync()
        {
            return await _context.ProjectCategories
                .Select(pc => new GetProjectCategoryItemResponse
                {
                    ProjectCategoryID = pc.ProjectCategoryID,
                    Title = pc.Title
                })
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<GetProjectCategoryResponse> GetProjectCategoryByIdAsync(int id)
        {
            if (id <= 0) throw new BadRequestException("ID must be positive");

            var projectCategory = await _context.ProjectCategories
                .Where(pc => pc.ProjectCategoryID == id)
                .Select(pc => new GetProjectCategoryResponse
                {
                    ProjectCategoryID = pc.ProjectCategoryID,
                    Title = pc.Title,
                    Description = pc.Description
                })
                .FirstOrDefaultAsync();

            if (projectCategory == null)
                throw new NotFoundException("ProjectCategory not found");
            else
                return projectCategory;
        }

        /// <inheritdoc/>
        public async Task CreateProjectCategoryAsync(CreateProjectCategoryRequest request)
        {
            // Проверка уникальности наименования
            if (await _context.ProjectCategories.AnyAsync(pc => pc.Title == request.Title))
            {
                throw new ConflictException("Категория с таким наименованием уже существует");
            }

            // Создание объекта пользователя
            ProjectCategory projectCategory = new ProjectCategory
            {
                Title = request.Title,
                Description = request.Description,
            };

            await _context.ProjectCategories.AddAsync(projectCategory);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateProjectCategoryAsync(int id, UpdateProjectCategoryRequest request)
        {
            var projectCategory = await _context.ProjectCategories.FindAsync(id);
            if (projectCategory == null)
                throw new NotFoundException("Категория не найдена");

            if (request.Title != null)
            {
                if (projectCategory.Title != request.Title &&
                    await _context.ProjectCategories.AnyAsync(pc => pc.Title == request.Title))
                {
                    throw new ConflictException("Категория с таким наименованием уже существует");
                }
                projectCategory.Title = request.Title;
            }

            if (request.Description != null)
                projectCategory.Description = request.Description;

            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteProjectCategoryAsync(int id)
        {
            var projectCategory = await _context.ProjectCategories.FindAsync(id);
            if (projectCategory == null)
                throw new NotFoundException("Категория не найдена");

            _context.ProjectCategories.Remove(projectCategory);
            await _context.SaveChangesAsync();
        }
    }
}
