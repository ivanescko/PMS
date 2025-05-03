using MediatR;
using PMS.Server.DTOs.SpecialityDTO.Queries;

namespace PMS.Server.Repositories.SpecialityRepository.Handlers.Queries.GetSpeciality
{
    /// <summary>
    /// Обработчик команды <see cref="GetSpecialityQuery"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует запрос на получение данных в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="ISpecialityRepository"/>.</param>
    public class GetSpecialityQueryHandler(ISpecialityRepository repository) : IRequestHandler<GetSpecialityQuery, GetSpecialityResponse>
    {
        private readonly ISpecialityRepository _repository = repository;

        /// <summary>
        /// Метод обработки запроса <see cref="GetSpecialityQuery"/>.
        /// </summary>
        /// <returns>Объект с данными <see cref="GetSpecialityResponse"/>.</returns>
        /// <param name="request">Запрос на получение данных.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>        
        public async Task<GetSpecialityResponse> Handle(GetSpecialityQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetSpecialityByIdAsync(request.Id);
        }
    }
}
