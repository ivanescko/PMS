using MediatR;

namespace PMS.Server.Repositories.SpecialityRepository.Handlers.Commands.UpdateSpeciality
{
    /// <summary>
    /// Команда обновления специальности.
    /// </summary>
    /// <param name="Id">Идентификатор.</param>
    /// <param name="Title">Наименование.</param>
    /// <param name="Description">Описание.</param>
    public sealed record UpdateSpecialityCommand(
        int Id,
        string? Title,
        string? Description
    ) : IRequest;
}
