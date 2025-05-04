using MediatR;
using PMS.Server.DTOs.ProjectCategoryDTO.Commands;

namespace PMS.Server.Repositories.ProjectCategoryRepository.Handlers.Commands.CreateProjectCategory
{
    /// <summary>
    /// Обработчик команды <see cref="CreateProjectCategoryCommand"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует создание сущности в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IProjectCategoryRepository"/>.</param>
    public class CreateProjectCategoryCommandHandler(IProjectCategoryRepository repository) : IRequestHandler<CreateProjectCategoryCommand>
    {
        private readonly IProjectCategoryRepository _repository = repository;

        /// <summary>
        /// Метод обработки команды <see cref="CreateProjectCategoryCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для создания.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(CreateProjectCategoryCommand command, CancellationToken cancellationToken)
        {
            var createProjectCategoryDto = new CreateProjectCategoryRequest
            {
                Title = command.Title,
                Description = command.Description,
            };

            await _repository.CreateProjectCategoryAsync(createProjectCategoryDto);
        }
    }
}
