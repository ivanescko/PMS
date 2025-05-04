using MediatR;
using PMS.Server.DTOs.DepartmentDTO.Commands;

namespace PMS.Server.Repositories.DepartmentRepository.Handlers.Commands.UpdateDepartment
{
    /// <summary>
    /// Обработчик команды <see cref="UpdateDepartmentCommand"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует обновление в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IDepartmentRepository"/>.</param>
    public class UpdateDepartmentCommandHandler(IDepartmentRepository repository) : IRequestHandler<UpdateDepartmentCommand>
    {
        private readonly IDepartmentRepository _repository = repository;

        /// <summary>
        /// Метод обработки команды <see cref="UpdateDepartmentCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для обновления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(UpdateDepartmentCommand command, CancellationToken cancellationToken)
        {
            await _repository.UpdateDepartmentAsync(
                id: command.Id,
                request: new UpdateDepartmentRequest
                {
                    Code = command.Code,
                    Title = command.Title,
                    Description = command.Description,
                }
            );
        }
    }
}
