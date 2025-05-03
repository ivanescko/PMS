using MediatR;

namespace PMS.Server.Repositories.SpecialityRepository.Handlers.Commands.DeleteSpeciality
{
    /// <summary>
    /// Команда удаления специальности.
    /// </summary>
    /// <param name="Id">Идентификатор специальности.</param>
    public sealed record DeleteSpecialityCommand(int Id) : IRequest;
}
