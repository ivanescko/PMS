using MediatR;

namespace PMS.Server.Repositories.ProjectTaskCategoryRepository.Handlers.Commands.DeleteProjectTaskCategory
{
    /// <summary>
    /// Команда удаления категории задач проекта.
    /// </summary>
    /// <param name="Id">Идентификатор категории задач проекта.</param>
    public sealed record DeleteProjectTaskCategoryCommand(int Id) : IRequest;
}
