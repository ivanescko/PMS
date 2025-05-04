using MediatR;

namespace PMS.Server.Repositories.ProjectCategoryRepository.Handlers.Commands.DeleteProjectCategory
{
    /// <summary>
    /// Команда удаления категории проекта.
    /// </summary>
    /// <param name="Id">Идентификатор категории проекта.</param>
    public sealed record DeleteProjectCategoryCommand(int Id) : IRequest;
}
