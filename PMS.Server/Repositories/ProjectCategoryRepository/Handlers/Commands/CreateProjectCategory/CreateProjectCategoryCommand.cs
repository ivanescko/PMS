using MediatR;

namespace PMS.Server.Repositories.ProjectCategoryRepository.Handlers.Commands.CreateProjectCategory
{
    /// <summary>
    /// Команда создания новой категории проекта.
    /// </summary>
    /// <param name="Title">Наименование.</param>
    /// <param name="Description">Описание.</param>
    public sealed record CreateProjectCategoryCommand(
        string Title,
        string Description
    ) : IRequest;
}
