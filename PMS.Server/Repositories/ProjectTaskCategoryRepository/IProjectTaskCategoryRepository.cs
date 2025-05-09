using PMS.Server.DTOs.ProjectTaskCategoryDTO.Commands;
using PMS.Server.DTOs.ProjectTaskCategoryDTO.Queries;
using PMS.Server.Exceptions;

namespace PMS.Server.Repositories.ProjectTaskCategoryRepository
{
    /// <summary>
    /// Интерфейс репозитория для работы с категориями задач проектов.
    /// </summary>
    /// <remarks>
    /// Описывает структуру репозитория для взаимодействия с сущностью категории задач проекта.
    /// </remarks>
    public interface IProjectTaskCategoryRepository
    {
        /// <summary>
        /// Метод получения списка категорий задач проектов.
        /// </summary>
        /// <returns>Список DTO с данными всех категорий задач проектов.</returns>
        Task<List<GetProjectTaskCategoryItemResponse>> GetProjectTaskCategoriesAsync();

        /// <summary>
        /// Метод получения категории задач проекта по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор категории задач проекта.</param>
        /// <returns>DTO с данными категории задач проекта.</returns>
        /// <exception cref="BadRequestException">Невалидные данные.</exception>
        /// <exception cref="NotFoundException">Ресурс не найден.</exception>
        Task<GetProjectTaskCategoryResponse> GetProjectTaskCategoryByIdAsync(int id);

        /// <summary>
        /// Метод создания категории задач проекта.
        /// </summary>
        /// <param name="request">Объект запроса, с данными новой категории задач проекта.</param>
        /// <exception cref="ConflictException">Конфликт данных.</exception>
        Task CreateProjectTaskCategoryAsync(CreateProjectTaskCategoryRequest request);

        /// <summary>
        /// Метод изменения категории задач проекта.
        /// </summary>
        /// <param name="id">Идентификатор категории задач проекта.</param>
        /// <param name="request">Объект запроса, с измененными данными категории задач проекта.</param>
        /// <exception cref="NotFoundException">Ресурс не найден.</exception>
        /// <exception cref="ConflictException">Конфликт данных.</exception>
        Task UpdateProjectTaskCategoryAsync(int id, UpdateProjectTaskCategoryRequest request);

        /// <summary>
        /// Метод удаления категории задач проекта.
        /// </summary>
        /// <param name="id">Идентификатор категории задач проекта.</param>
        /// <exception cref="NotFoundException">Ресурс не найден.</exception>
        Task DeleteProjectTaskCategoryAsync(int id);
    }
}
