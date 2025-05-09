using FluentValidation;

namespace PMS.Server.Repositories.ProjectTaskStatusRepository.Handlers.Commands.CreateProjectTaskStatus
{
    /// <summary>
    /// Валидатор для команды <see cref="CreateProjectTaskStatusCommand"/>.
    /// </summary>
    /// <remarks>
    /// Проверяет:
    /// <list type="bullet">
    /// <item><description>Наличие обязательных полей</description></item>
    /// <item><description>Длину наименования (макс. 50 символов)</description></item>
    /// <item><description>Длину описания (макс. 200 символов)</description></item>
    /// </list>
    /// </remarks>
    public class CreateProjectTaskStatusCommandValidator : AbstractValidator<CreateProjectTaskStatusCommand>
    {
        /// <summary>
        /// Конструктор класса <see cref="CreateProjectTaskStatusCommandValidator"/>.
        /// </summary>
        /// <remarks>
        /// Настраивает правила валидации.
        /// </remarks>
        public CreateProjectTaskStatusCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Наименование обязательно")
                .MaximumLength(50).WithMessage("Наименование не длиннее 50 символов");

            RuleFor(x => x.Description)
                .MaximumLength(200).WithMessage("Описание не длиннее 200 символов");
        }
    }
}
