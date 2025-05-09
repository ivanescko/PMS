using MediatR;

namespace PMS.Server.Repositories.ProjectTaskCategoryRepository.Handlers.Commands.UpdateProjectTaskCategory
{
    /// <summary>
    /// Команда обновления категории задач проекта.
    /// </summary>
    /// <param name="Id">Идентификатор.</param>
    /// <param name="Title">Наименование.</param>
    /// <param name="Description">Описание.</param>
    public sealed record UpdateProjectTaskCategoryCommand(
        int Id,
        string? Title,
        string? Description
    ) : IRequest;
}
