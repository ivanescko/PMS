using MediatR;

namespace PMS.Server.Repositories.SprintTaskStatusRepository.Handlers.Commands.CreateSprintTaskStatus
{
    /// <summary>
    /// Команда создания нового статуса задач проекта.
    /// </summary>
    /// <param name="Title">Наименование.</param>
    ///// <param name = "Description" > Описание.</ param >
    public sealed record CreateSprintTaskStatusCommand(
        string Title
        //string Description
    ) : IRequest;
}
