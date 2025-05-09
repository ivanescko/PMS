using MediatR;

namespace PMS.Server.Repositories.ProjectTaskStatusRepository.Handlers.Commands.CreateProjectTaskStatus
{
    /// <summary>
    /// Команда создания нового статуса задач проекта.
    /// </summary>
    /// <param name="Title">Наименование.</param>
    /// <param name="Description">Описание.</param>
    public sealed record CreateProjectTaskStatusCommand(
        string Title,
        string Description
    ) : IRequest;
}
