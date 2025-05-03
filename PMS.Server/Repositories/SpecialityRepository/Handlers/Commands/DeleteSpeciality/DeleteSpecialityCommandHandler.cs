using MediatR;

namespace PMS.Server.Repositories.SpecialityRepository.Handlers.Commands.DeleteSpeciality
{
    /// <summary>
    /// Обработчик команды <see cref="DeleteSpecialityCommand"/>.
    /// </summary>
    /// <remarks>
    /// Делегирует удаление в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="ISpecialityRepository"/>.</param>
    public class DeleteSpecialityCommandHandler(ISpecialityRepository repository) : IRequestHandler<DeleteSpecialityCommand>
    {
        private readonly ISpecialityRepository _repository = repository;

        /// <summary>
        /// Метод обработки команды <see cref="DeleteSpecialityCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для удаления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(DeleteSpecialityCommand command, CancellationToken cancellationToken)
        {
            await _repository.DeleteSpecialityAsync(command.Id);
        }
    }
}
