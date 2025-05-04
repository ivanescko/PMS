using MediatR;

namespace PMS.Server.Repositories.DepartmentRepository.Handlers.Commands.UpdateDepartment
{
    /// <summary>
    /// Команда обновления отдела.
    /// </summary>
    /// <param name="Id">Идентификатор.</param>
    /// <param name="Code">Код.</param>
    /// <param name="Title">Наименование.</param>
    /// <param name="Description">Описание.</param>
    public sealed record UpdateDepartmentCommand(
        int Id,
        string? Code,
        string? Title,
        string? Description
    ) : IRequest;
}
