using Microsoft.EntityFrameworkCore;
using PMS.Model.Context;
using PMS.Model.Entities;
using PMS.Server.DTOs.DepartmentDTO.Commands;
using PMS.Server.DTOs.DepartmentDTO.Queries;
using PMS.Server.Exceptions;

namespace PMS.Server.Repositories.DepartmentRepository
{
    /// <summary>
    /// Репозиторий для работы с сущностью <see cref="Department"/>.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    public class DepartmentRepository(PmsDbContext context) :IDepartmentRepository
    {
        private readonly PmsDbContext _context = context;

        /// <inheritdoc/>
        public async Task<List<GetDepartmentItemResponse>> GetDepartmentsAsync()
        {
            return await _context.Departments
                .Select(d => new GetDepartmentItemResponse
                {
                    DepartmentID = d.DepartmentID,
                    Title = d.Title
                })
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<GetDepartmentResponse> GetDepartmentByIdAsync(int id)
        {
            if (id <= 0) throw new BadRequestException("ID must be positive");

            var department = await _context.Departments
                .Where(d => d.DepartmentID == id)
                .Select(d => new GetDepartmentResponse
                {
                    DepartmentID = d.DepartmentID,
                    Code = d.Code,
                    Title = d.Title,
                    Description = d.Description
                })
                .FirstOrDefaultAsync();

            if (department == null)
                throw new NotFoundException("Department not found");
            else
                return department;
        }

        /// <inheritdoc/>
        public async Task CreateDepartmentAsync(CreateDepartmentRequest request)
        {
            // Проверка уникальности наименования
            if (await _context.Departments.AnyAsync(d => d.Title == request.Title))
            {
                throw new ConflictException("Отдел с таким наименованием уже существует");
            }

            // Создание объекта пользователя
            Department department = new Department
            {
                Code = request.Code,
                Title = request.Title,
                Description = request.Description,
            };

            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateDepartmentAsync(int id, UpdateDepartmentRequest request)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
                throw new NotFoundException("Отдел не найден");

            if (request.Title != null)
            {
                if (department.Title != request.Title &&
                    await _context.Departments.AnyAsync(s => s.Title == request.Title))
                {
                    throw new ConflictException("Отдел с таким наименованием уже существует");
                }
                department.Title = request.Title;
            }

            if (request.Code != null)
                department.Code = request.Code;

            if (request.Description != null)
                department.Description = request.Description;

            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteDepartmentAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
                throw new NotFoundException("Отдел не найден");

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
        }
    }
}
