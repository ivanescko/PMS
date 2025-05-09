using MediatR;

namespace PMS.Server.Repositories.ProjectTaskCategoryRepository.Handlers.Commands.CreateProjectTaskCategory
{
    /// <summary>
    /// Команда создания новой категории задач проекта.
    /// </summary>
    /// <param name="Title">Наименование.</param>
    /// <param name="Description">Описание.</param>
    public sealed record CreateProjectTaskCategoryCommand(
        string Title,
        string Description
    ) : IRequest;
}
