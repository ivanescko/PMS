using MediatR;

namespace PMS.Server.Repositories.SpecialityRepository.Handlers.Commands.CreateSpeciality
{
    /// <summary>
    /// Команда создания новой специальности.
    /// </summary>
    /// <param name="Title">Наименование.</param>
    /// <param name="Description">Описание.</param>
    public sealed record CreateSpecialityCommand(
        string Title,
        string Description
    ) : IRequest;
}
