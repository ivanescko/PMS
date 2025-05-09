using MediatR;
using PMS.Server.DTOs.ProjectTaskCategoryDTO.Commands;

namespace PMS.Server.Repositories.ProjectTaskCategoryRepository.Handlers.Commands.CreateProjectTaskCategory
{
    /// <summary>
    /// Обработчик команды <see cref="CreateProjectTaskCategoryCommand"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует создание сущности в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IProjectTaskCategoryRepository"/>.</param>
    public class CreateProjectTaskCategoryCommandHandler(IProjectTaskCategoryRepository repository) : IRequestHandler<CreateProjectTaskCategoryCommand>
    {
        private readonly IProjectTaskCategoryRepository _repository = repository;

        /// <summary>
        /// Метод обработки команды <see cref="CreateProjectTaskCategoryCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для создания.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(CreateProjectTaskCategoryCommand command, CancellationToken cancellationToken)
        {
            var createProjectTaskCategoryDto = new CreateProjectTaskCategoryRequest
            {
                Title = command.Title,
                Description = command.Description,
            };

            await _repository.CreateProjectTaskCategoryAsync(createProjectTaskCategoryDto);
        }
    }
}
