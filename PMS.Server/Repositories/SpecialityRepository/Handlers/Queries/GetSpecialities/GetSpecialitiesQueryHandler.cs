using MediatR;
using PMS.Server.DTOs.SpecialityDTO.Queries;

namespace PMS.Server.Repositories.SpecialityRepository.Handlers.Queries.GetSpecialities
{
    /// <summary>
    /// Обработчик команды <see cref="GetSpecialitiesQuery"/>.
    /// </summary>
    /// <remarks>
    /// Делегирует запрос на получение списка в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="ISpecialityRepository"/>.</param>
    public class GetSpecialitiesQueryHandler(ISpecialityRepository repository) : IRequestHandler<GetSpecialitiesQuery, List<GetSpecialityItemResponse>>
    {
        private readonly ISpecialityRepository _repository = repository;

        /// <summary>
        /// Метод обработки запроса <see cref="GetSpecialitiesQuery"/>.
        /// </summary>
        /// <returns>Список объектов <see cref="GetSpecialityItemResponse"/>.</returns>
        /// <param name="request">Запрос на получение списка.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task<List<GetSpecialityItemResponse>> Handle(GetSpecialitiesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetSpecialitiesAsync();
        }
    }
}
