using MediatR;

namespace PMS.Server.Repositories.ProjectCategoryRepository.Handlers.Commands.DeleteProjectCategory
{
    /// <summary>
    /// Обработчик команды <see cref="DeleteProjectCategoryCommand"/>.
    /// </summary>
    /// <remarks>
    /// Делегирует удаление в репозиторий.
    /// </remarks>
    /// <param name="repository">Репозиторий реализующий интерфейс <see cref="IProjectCategoryRepository"/>.</param>
    public class DeleteProjectCategoryCommandHandler(IProjectCategoryRepository repository) : IRequestHandler<DeleteProjectCategoryCommand>
    {
        private readonly IProjectCategoryRepository _repository = repository;

        /// <summary>
        /// Метод обработки команды <see cref="DeleteProjectCategoryCommand"/>.
        /// </summary>
        /// <param name="command">Команда с данными для удаления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(DeleteProjectCategoryCommand command, CancellationToken cancellationToken)
        {
            await _repository.DeleteProjectCategoryAsync(command.Id);
        }
    }
}
