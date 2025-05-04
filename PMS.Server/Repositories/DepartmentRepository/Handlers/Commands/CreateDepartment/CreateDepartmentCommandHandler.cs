using MediatR;
using PMS.Server.DTOs.DepartmentDTO.Commands;

namespace PMS.Server.Repositories.DepartmentRepository.Handlers.Commands.CreateDepartment
{
    /// <summary>
    /// Обработчик команды <see cref="CreateDepartmentCommand"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует создание сущности в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IDepartmentRepository"/>.</param>
    public class CreateDepartmentCommandHandler(IDepartmentRepository repository) : IRequestHandler<CreateDepartmentCommand>
    {
        private readonly IDepartmentRepository _repository = repository;

        /// <summary>
        /// Метод обработки команды <see cref="CreateDepartmentCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для создания.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(CreateDepartmentCommand command, CancellationToken cancellationToken)
        {
            var createDepartmentDto = new CreateDepartmentRequest
            {
                Code = command.Code,
                Title = command.Title,
                Description = command.Description,
            };

            await _repository.CreateDepartmentAsync(createDepartmentDto);
        }
    }
}
