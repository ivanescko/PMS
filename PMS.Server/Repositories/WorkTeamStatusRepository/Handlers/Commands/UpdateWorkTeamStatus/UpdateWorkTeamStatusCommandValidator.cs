using FluentValidation;
using PMS.Server.DTOs.WorkTeamStatusDTO.Commands;

namespace PMS.Server.Repositories.WorkTeamStatusRepository.Handlers.Commands.UpdateWorkTeamStatus
{
    /// <summary>
    /// Валидатор для команды <see cref="UpdateWorkTeamStatusRequest"/>.
    /// </summary>
    /// <remarks>
    /// Проверяет:
    /// <list type="bullet">
    /// <item><description>Наличие обязательных полей</description></item>
    /// <item><description>Длину наименования (макс. 50 символов)</description></item>
    /// <item><description>Длину описания (макс. 200 символов)</description></item>
    /// </list>
    /// </remarks>
    public class UpdateWorkTeamStatusCommandValidator : AbstractValidator<UpdateWorkTeamStatusRequest>
    {
        /// <summary>
        /// Конструктор класса <see cref="UpdateWorkTeamStatusCommandValidator"/>.
        /// </summary>
        /// <remarks>
        /// Настраивает правила валидации.
        /// </remarks>
        public UpdateWorkTeamStatusCommandValidator()
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
