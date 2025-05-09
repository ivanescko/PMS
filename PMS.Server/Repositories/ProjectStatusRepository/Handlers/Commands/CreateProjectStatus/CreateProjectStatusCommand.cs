using MediatR;

namespace PMS.Server.Repositories.ProjectStatusRepository.Handlers.Commands.CreateProjectStatus
{
    /// <summary>
    /// Команда создания нового статуса проекта.
    /// </summary>
    /// <param name="Title">Наименование.</param>
    /// <param name="Description">Описание.</param>
    public sealed record CreateProjectStatusCommand(
        string Title,
        string Description
    ) : IRequest;
}
