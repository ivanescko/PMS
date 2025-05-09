using MediatR;

namespace PMS.Server.Repositories.ProjectTaskCategoryRepository.Handlers.Commands.DeleteProjectTaskCategory
{
    /// <summary>
    /// Обработчик команды <see cref="DeleteProjectTaskCategoryCommand"/>.
    /// </summary>
    /// <remarks>
    /// Делегирует удаление в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IProjectTaskCategoryRepository"/>.</param>
    public class DeleteProjectTaskCategoryCommandHandler(IProjectTaskCategoryRepository repository) : IRequestHandler<DeleteProjectTaskCategoryCommand>
    {
        private readonly IProjectTaskCategoryRepository _repository = repository;

        /// <summary>
        /// Метод обработки команды <see cref="DeleteProjectTaskCategoryCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для удаления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(DeleteProjectTaskCategoryCommand command, CancellationToken cancellationToken)
        {
            await _repository.DeleteProjectTaskCategoryAsync(command.Id);
        }
    }
}
