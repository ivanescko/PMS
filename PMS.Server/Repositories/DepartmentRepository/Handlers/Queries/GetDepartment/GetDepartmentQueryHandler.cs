using MediatR;
using PMS.Server.DTOs.DepartmentDTO.Queries;

namespace PMS.Server.Repositories.DepartmentRepository.Handlers.Queries.GetDepartment
{
    /// <summary>
    /// Обработчик команды <see cref="GetDepartmentQuery"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует запрос на получение данных в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IDepartmentRepository"/>.</param>
    public class GetDepartmentQueryHandler(IDepartmentRepository repository) : IRequestHandler<GetDepartmentQuery, GetDepartmentResponse>
    {
        private readonly IDepartmentRepository _repository = repository;

        /// <summary>
        /// Метод обработки запроса <see cref="GetDepartmentQuery"/>.
        /// </summary>
        /// <returns>Объект с данными <see cref="GetDepartmentResponse"/>.</returns>
        /// <param name="request">Запрос на получение данных.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>        
        public async Task<GetDepartmentResponse> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetDepartmentByIdAsync(request.Id);
        }
    }
}
