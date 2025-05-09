using MediatR;

namespace PMS.Server.Repositories.WorkTeamStatusRepository.Handlers.Commands.CreateWorkTeamStatus
{
    /// <summary>
    /// Команда создания нового статуса команд.
    /// </summary>
    /// <param name="Title">Наименование.</param>
    /// <param name="Description">Описание.</param>
    public sealed record CreateWorkTeamStatusCommand(
        string Title,
        string Description
    ) : IRequest;
}
