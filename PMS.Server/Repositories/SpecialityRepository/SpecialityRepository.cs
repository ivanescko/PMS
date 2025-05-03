using Microsoft.EntityFrameworkCore;
using PMS.Model.Context;
using PMS.Model.Entities;
using PMS.Server.DTOs.SpecialityDTO.Commands;
using PMS.Server.DTOs.SpecialityDTO.Queries;
using PMS.Server.DTOs.UserDTO.Commands;
using PMS.Server.DTOs.UserDTO.Queries;
using PMS.Server.Exceptions;

namespace PMS.Server.Repositories.SpecialityRepository
{
    /// <summary>
    /// Репозиторий для работы с сущностью <see cref="Speciality"/>.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    public class SpecialityRepository(PmsDbContext context) : ISpecialityRepository
    {
        private readonly PmsDbContext _context = context;

        /// <inheritdoc/>
        public async Task<List<GetSpecialityItemResponse>> GetSpecialitiesAsync()
        {
            return await _context.Specialities
                .Select(s => new GetSpecialityItemResponse
                {
                    SpecialityID = s.SpecialityID,
                    Title = s.Title
                })
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<GetSpecialityResponse> GetSpecialityByIdAsync(int id)
        {
            if (id <= 0) throw new BadRequestException("ID must be positive");

            var speciality = await _context.Specialities
                .Where(s => s.SpecialityID == id)
                .Select(u => new GetSpecialityResponse
                {
                    SpecialityID = u.SpecialityID,
                    Title = u.Title,
                    Description = u.Description
                })
                .FirstOrDefaultAsync();

            if (speciality == null)
                throw new NotFoundException("Speciality not found");
            else
                return speciality;
        }

        /// <inheritdoc/>
        public async Task CreateSpecialityAsync(CreateSpecialityRequest request)
        {
            // Проверка уникальности наименования
            if (await _context.Specialities.AnyAsync(s => s.Title == request.Title))
            {
                throw new ConflictException("Специальность с таким наименованием уже существует");
            }

            // Создание объекта пользователя
            Speciality speciality = new Speciality 
            {
                Title = request.Title,
                Description = request.Description,
            };

            await _context.Specialities.AddAsync(speciality);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateSpecialityAsync(int id, UpdateSpecialityRequest request)
        {
            var speciality = await _context.Specialities.FindAsync(id);
            if (speciality == null)
                throw new NotFoundException("Специальность не найден");

            if (request.Title != null)
            {
                if (speciality.Title != request.Title &&
                    await _context.Specialities.AnyAsync(s => s.Title == request.Title))
                {
                    throw new ConflictException("Специальность с таким наименованием уже существует");
                }
                speciality.Title = request.Title;
            }

            if (request.Description != null)
                speciality.Description = request.Description;

            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteSpecialityAsync(int id)
        {
            var speciality = await _context.Specialities.FindAsync(id);
            if (speciality == null)
                throw new NotFoundException("Специальность не найдена");

            _context.Specialities.Remove(speciality);
            await _context.SaveChangesAsync();
        }
    }
}
