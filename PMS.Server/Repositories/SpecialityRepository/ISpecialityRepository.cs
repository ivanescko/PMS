using PMS.Server.DTOs.SpecialityDTO.Commands;
using PMS.Server.DTOs.SpecialityDTO.Queries;
using PMS.Server.Exceptions;

namespace PMS.Server.Repositories.SpecialityRepository
{
    /// <summary>
    /// Интерфейс репозитория для работы с специальностями.
    /// </summary>
    /// <remarks>
    /// Описывает структуру репозитория для взаимодействия с сущностью специальности.
    /// </remarks>
    public interface ISpecialityRepository
    {
        /// <summary>
        /// Метод получения списка специальностей.
        /// </summary>
        /// <returns>Список DTO с данными всех специальностей.</returns>
        Task<List<GetSpecialityItemResponse>> GetSpecialitiesAsync();

        /// <summary>
        /// Метод получения специальности по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор специальности.</param>
        /// <returns>DTO с данными специальности.</returns>
        /// <exception cref="BadRequestException">Невалидные данные.</exception>
        /// <exception cref="NotFoundException">Ресурс не найден.</exception>
        Task<GetSpecialityResponse> GetSpecialityByIdAsync(int id);

        /// <summary>
        /// Метод создания специальности.
        /// </summary>
        /// <param name="request">Объект запроса, с данными новой специальности.</param>
        /// <exception cref="ConflictException">Конфликт данных.</exception>
        Task CreateSpecialityAsync(CreateSpecialityRequest request);

        /// <summary>
        /// Метод изменения специальности.
        /// </summary>
        /// <param name="id">Идентификатор специальности.</param>
        /// <param name="request">Объект запроса, с измененными данными специальности.</param>
        /// <exception cref="NotFoundException">Ресурс не найден.</exception>
        /// <exception cref="ConflictException">Конфликт данных.</exception>
        Task UpdateSpecialityAsync(int id, UpdateSpecialityRequest request);

        /// <summary>
        /// Метод удаления специальности.
        /// </summary>
        /// <param name="id">Идентификатор специальности.</param>
        /// <exception cref="NotFoundException">Ресурс не найден.</exception>
        Task DeleteSpecialityAsync(int id);
    }
}
