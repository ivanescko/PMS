using FluentValidation;
using PMS.Server.DTOs.ProjectStatusDTO.Commands;

namespace PMS.Server.Repositories.ProjectStatusRepository.Handlers.Commands.UpdateProjectStatus
{
    /// <summary>
    /// Валидатор для команды <see cref="UpdateProjectStatusRequest"/>.
    /// </summary>
    /// <remarks>
    /// Проверяет:
    /// <list type="bullet">
    /// <item><description>Наличие обязательных полей</description></item>
    /// <item><description>Длину наименования (макс. 50 символов)</description></item>
    /// <item><description>Длину описания (макс. 200 символов)</description></item>
    /// </list>
    /// </remarks>
    public class UpdateProjectStatusCommandValidator : AbstractValidator<UpdateProjectStatusRequest>
    {
        /// <summary>
        /// Конструктор класса <see cref="UpdateProjectStatusCommandValidator"/>.
        /// </summary>
        /// <remarks>
        /// Настраивает правила валидации.
        /// </remarks>
        public UpdateProjectStatusCommandValidator()
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
