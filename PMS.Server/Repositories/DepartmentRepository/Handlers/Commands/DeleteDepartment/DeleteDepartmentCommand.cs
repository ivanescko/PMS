using MediatR;

namespace PMS.Server.Repositories.DepartmentRepository.Handlers.Commands.DeleteDepartment
{
    /// <summary>
    /// Команда удаления отдела.
    /// </summary>
    /// <param name="Id">Идентификатор отдела.</param>
    public sealed record DeleteDepartmentCommand(int Id) : IRequest;
}
