using MediatR;
using PMS.Server.DTOs.ProjectCategoryDTO.Commands;

namespace PMS.Server.Repositories.ProjectCategoryRepository.Handlers.Commands.UpdateProjectCategory
{
    /// <summary>
    /// Обработчик команды <see cref="UpdateProjectCategoryCommand"/>.
    /// </summary>
    /// <remarks>
    /// Преобразует команду в DTO и делегирует обновление в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IProjectCategoryRepository"/>.</param>
    public class UpdateProjectCategoryCommandHandler(IProjectCategoryRepository repository) : IRequestHandler<UpdateProjectCategoryCommand>
    {
        private readonly IProjectCategoryRepository _repository = repository;

        /// <summary>
        /// Метод обработки команды <see cref="UpdateProjectCategoryCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для обновления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(UpdateProjectCategoryCommand command, CancellationToken cancellationToken)
        {
            await _repository.UpdateProjectCategoryAsync(
                id: command.Id,
                request: new UpdateProjectCategoryRequest
                {
                    Title = command.Title,
                    Description = command.Description,
                }
            );
        }
    }
}
