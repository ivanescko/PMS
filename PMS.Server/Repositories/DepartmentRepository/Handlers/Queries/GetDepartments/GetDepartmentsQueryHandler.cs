using MediatR;
using PMS.Server.DTOs.DepartmentDTO.Queries;

namespace PMS.Server.Repositories.DepartmentRepository.Handlers.Queries.GetDepartments
{
    /// <summary>
    /// Обработчик команды <see cref="GetDepartmentsQuery"/>.
    /// </summary>
    /// <remarks>
    /// Делегирует запрос на получение списка в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IDepartmentRepository"/>.</param>
    public class GetDepartmentsQueryHandler(IDepartmentRepository repository) : IRequestHandler<GetDepartmentsQuery, List<GetDepartmentItemResponse>>
    {
        private readonly IDepartmentRepository _repository = repository;

        /// <summary>
        /// Метод обработки запроса <see cref="GetDepartmentsQuery"/>.
        /// </summary>
        /// <returns>Список объектов <see cref="GetDepartmentItemResponse"/>.</returns>
        /// <param name="request">Запрос на получение списка.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task<List<GetDepartmentItemResponse>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetDepartmentsAsync();
        }
    }
}
