using FluentValidation;
using PMS.Server.DTOs.SprintTaskStatusDTO.Commands;

namespace PMS.Server.Repositories.SprintTaskStatusRepository.Handlers.Commands.UpdateSprintTaskStatus
{
    /// <summary>
    /// Валидатор для команды <see cref="UpdateSprintTaskStatusRequest"/>.
    /// </summary>
    /// <remarks>
    /// Проверяет:
    /// <list type="bullet">
    /// <item><description>Наличие обязательных полей</description></item>
    /// <item><description>Длину наименования (макс. 50 символов)</description></item>
    /// <item><description>Длину описания (макс. 200 символов)</description></item>
    /// </list>
    /// </remarks>
    public class UpdateSprintTaskStatusCommandValidator : AbstractValidator<UpdateSprintTaskStatusRequest>
    {
        /// <summary>
        /// Конструктор класса <see cref="UpdateSprintTaskStatusCommandValidator"/>.
        /// </summary>
        /// <remarks>
        /// Настраивает правила валидации.
        /// </remarks>
        public UpdateSprintTaskStatusCommandValidator()
        {
            RuleFor(x => x.Title)
                .MaximumLength(50).When(x => x.Title != null)
                .WithMessage("Наименование не длиннее 50 символов");

            //RuleFor(x => x.Description)
            //    .MaximumLength(200).When(x => x.Description != null)
            //    .WithMessage("Описание не длиннее 200 символов");
        }
    }
}
