using PMS.Server.DTOs.ProjectCategoryDTO.Commands;
using PMS.Server.DTOs.ProjectCategoryDTO.Queries;
using PMS.Server.Exceptions;

namespace PMS.Server.Repositories.ProjectCategoryRepository
{
    /// <summary>
    /// Интерфейс репозитория для работы с категориями проектов.
    /// </summary>
    /// <remarks>
    /// Описывает структуру репозитория для взаимодействия с сущностью категории проекта.
    /// </remarks>
    public interface IProjectCategoryRepository
    {
        /// <summary>
        /// Метод получения списка категорий проектов.
        /// </summary>
        /// <returns>Список DTO с данными всех категорий проектов.</returns>
        Task<List<GetProjectCategoryItemResponse>> GetProjectCategoriesAsync();

        /// <summary>
        /// Метод получения категории проекта по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор категории проекта.</param>
        /// <returns>DTO с данными категории проекта.</returns>
        /// <exception cref="BadRequestException">Невалидные данные.</exception>
        /// <exception cref="NotFoundException">Ресурс не найден.</exception>
        Task<GetProjectCategoryResponse> GetProjectCategoryByIdAsync(int id);

        /// <summary>
        /// Метод создания категории проекта.
        /// </summary>
        /// <param name="request">Объект запроса, с данными новой категории проекта.</param>
        /// <exception cref="ConflictException">Конфликт данных.</exception>
        Task CreateProjectCategoryAsync(CreateProjectCategoryRequest request);

        /// <summary>
        /// Метод изменения категории проекта.
        /// </summary>
        /// <param name="id">Идентификатор категории проекта.</param>
        /// <param name="request">Объект запроса, с измененными данными категории проекта.</param>
        /// <exception cref="NotFoundException">Ресурс не найден.</exception>
        /// <exception cref="ConflictException">Конфликт данных.</exception>
        Task UpdateProjectCategoryAsync(int id, UpdateProjectCategoryRequest request);

        /// <summary>
        /// Метод удаления категории проекта.
        /// </summary>
        /// <param name="id">Идентификатор категории проекта.</param>
        /// <exception cref="NotFoundException">Ресурс не найден.</exception>
        Task DeleteProjectCategoryAsync(int id);
    }
}
