using MediatR;
using PMS.Server.DTOs.SpecialityDTO.Commands;

namespace PMS.Server.Repositories.SpecialityRepository.Handlers.Commands.CreateSpeciality
{
    /// <summary>
    /// Обработчик команды <see cref="CreateSpecialityCommand"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует создание сущности в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="ISpecialityRepository"/>.</param>
    public class CreateSpecialityCommandHandler(ISpecialityRepository repository) : IRequestHandler<CreateSpecialityCommand>
    {
        private readonly ISpecialityRepository _repository = repository;

        /// <summary>
        /// Метод обработки команды <see cref="CreateSpecialityCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для создания.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(CreateSpecialityCommand command, CancellationToken cancellationToken)
        {
            var createSpecialityDto = new CreateSpecialityRequest
            {
                Title = command.Title,
                Description = command.Description,
            };

            await _repository.CreateSpecialityAsync(createSpecialityDto);
        }
    }
}
