using MediatR;

namespace PMS.Server.Repositories.DepartmentRepository.Handlers.Commands.DeleteDepartment
{
    /// <summary>
    /// Обработчик команды <see cref="DeleteDepartmentCommand"/>.
    /// </summary>
    /// <remarks>
    /// Делегирует удаление в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IDepartmentRepository"/>.</param>
    public class DeleteDepartmentCommandHandler(IDepartmentRepository repository) : IRequestHandler<DeleteDepartmentCommand>
    {
        private readonly IDepartmentRepository _repository = repository;

        /// <summary>
        /// Метод обработки команды <see cref="DeleteDepartmentCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для удаления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(DeleteDepartmentCommand command, CancellationToken cancellationToken)
        {
            await _repository.DeleteDepartmentAsync(command.Id);
        }
    }
}
