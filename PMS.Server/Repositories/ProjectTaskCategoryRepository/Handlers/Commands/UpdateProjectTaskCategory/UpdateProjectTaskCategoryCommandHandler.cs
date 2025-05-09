using MediatR;
using PMS.Server.DTOs.ProjectTaskCategoryDTO.Commands;

namespace PMS.Server.Repositories.ProjectTaskCategoryRepository.Handlers.Commands.UpdateProjectTaskCategory
{
    /// <summary>
    /// Обработчик команды <see cref="UpdateProjectTaskCategoryCommand"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует обновление в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IProjectTaskCategoryRepository"/>.</param>
    public class UpdateProjectTaskCategoryCommandHandler(IProjectTaskCategoryRepository repository) : IRequestHandler<UpdateProjectTaskCategoryCommand>
    {
        private readonly IProjectTaskCategoryRepository _repository = repository;

        /// <summary>
        /// Метод обработки команды <see cref="UpdateProjectTaskCategoryCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для обновления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(UpdateProjectTaskCategoryCommand command, CancellationToken cancellationToken)
        {
            await _repository.UpdateProjectTaskCategoryAsync(
                id: command.Id,
                request: new UpdateProjectTaskCategoryRequest
                {
                    Title = command.Title,
                    Description = command.Description,
                }
            );
        }
    }
}
