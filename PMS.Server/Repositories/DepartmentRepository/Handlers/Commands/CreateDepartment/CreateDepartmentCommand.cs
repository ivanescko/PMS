using MediatR;

namespace PMS.Server.Repositories.DepartmentRepository.Handlers.Commands.CreateDepartment
{
    /// <summary>
    /// Команда создания нового отдела.
    /// </summary>
    /// <param name="Code">Код.</param>
    /// <param name="Title">Наименование.</param>
    /// <param name="Description">Описание.</param>
    public sealed record CreateDepartmentCommand(
        string Code,
        string Title,
        string Description
    ) : IRequest;
}
