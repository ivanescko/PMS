using FluentValidation;
using PMS.Server.DTOs.WorkTeamRoleDTO.Commands;

namespace PMS.Server.Repositories.WorkTeamRoleRepository.Handlers.Commands.UpdateWorkTeamRole
{
    /// <summary>
    /// Валидатор для команды <see cref="UpdateWorkTeamRoleRequest"/>.
    /// </summary>
    /// <remarks>
    /// Проверяет:
    /// <list type="bullet">
    /// <item><description>Наличие обязательных полей</description></item>
    /// <item><description>Длину наименования (макс. 50 символов)</description></item>
    /// <item><description>Длину описания (макс. 200 символов)</description></item>
    /// </list>
    /// </remarks>
    public class UpdateWorkTeamRoleCommandValidator : AbstractValidator<UpdateWorkTeamRoleRequest>
    {
        /// <summary>
        /// Конструктор класса <see cref="UpdateWorkTeamRoleCommandValidator"/>.
        /// </summary>
        /// <remarks>
        /// Настраивает правила валидации.
        /// </remarks>
        public UpdateWorkTeamRoleCommandValidator()
        {
            RuleFor(x => x.Title)
                .MaximumLength(50).When(x => x.Title != null)
                .WithMessage("Наименование не длиннее 50 символов");

            RuleFor(x => x.Description)
                .MaximumLength(200).When(x => x.Description != null)
                .WithMessage("Описание не длиннее 200 символов");
        }
    }
}
