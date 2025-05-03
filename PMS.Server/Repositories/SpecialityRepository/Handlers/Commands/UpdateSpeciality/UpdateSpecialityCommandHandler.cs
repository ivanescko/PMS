using MediatR;
using PMS.Server.DTOs.SpecialityDTO.Commands;

namespace PMS.Server.Repositories.SpecialityRepository.Handlers.Commands.UpdateSpeciality
{
    /// <summary>
    /// Обработчик команды <see cref="UpdateSpecialityCommand"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует обновление в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="ISpecialityRepository"/>.</param>
    public class UpdateSpecialityCommandHandler(ISpecialityRepository repository) : IRequestHandler<UpdateSpecialityCommand>
    {
        private readonly ISpecialityRepository _repository = repository;

        /// <summary>
        /// Метод обработки команды <see cref="UpdateSpecialityCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для обновления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(UpdateSpecialityCommand command, CancellationToken cancellationToken)
        {
            await _repository.UpdateSpecialityAsync(
                id: command.Id,
                request: new UpdateSpecialityRequest
                {
                    Title = command.Title,
                    Description = command.Description,
                }
            );
        }
    }
}
