using MediatR;

namespace PMS.Server.Repositories.ProjectCategoryRepository.Handlers.Commands.UpdateProjectCategory
{
    /// <summary>
    /// Команда обновления категории проекта.
    /// </summary>
    /// <param name="Id">Идентификатор.</param>
    /// <param name="Title">Наименование.</param>
    /// <param name="Description">Описание.</param>
    public sealed record UpdateProjectCategoryCommand(
        int Id,
        string? Title,
        string? Description
    ) : IRequest;
}
