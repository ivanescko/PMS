using FluentValidation;
using PMS.Server.DTOs.ProjectTaskStatusDTO.Commands;

namespace PMS.Server.Repositories.ProjectTaskStatusRepository.Handlers.Commands.UpdateProjectTaskStatus
{
    /// <summary>
    /// Валидатор для команды <see cref="UpdateProjectTaskStatusRequest"/>.
    /// </summary>
    /// <remarks>
    /// Проверяет:
    /// <list type="bullet">
    /// <item><description>Наличие обязательных полей</description></item>
    /// <item><description>Длину наименования (макс. 50 символов)</description></item>
    /// <item><description>Длину описания (макс. 200 символов)</description></item>
    /// </list>
    /// </remarks>
    public class UpdateProjectTaskStatusCommandValidator : AbstractValidator<UpdateProjectTaskStatusRequest>
    {
        /// <summary>
        /// Конструктор класса <see cref="UpdateProjectTaskStatusCommandValidator"/>.
        /// </summary>
        /// <remarks>
        /// Настраивает правила валидации.
        /// </remarks>
        public UpdateProjectTaskStatusCommandValidator()
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
