using FluentValidation;

namespace PMS.Server.Repositories.SprintTaskStatusRepository.Handlers.Commands.CreateSprintTaskStatus
{
    /// <summary>
    /// Валидатор для команды <see cref="CreateSprintTaskStatusCommand"/>.
    /// </summary>
    /// <remarks>
    /// Проверяет:
    /// <list type="bullet">
    /// <item><description>Наличие обязательных полей</description></item>
    /// <item><description>Длину наименования (макс. 50 символов)</description></item>
    /// </list>
    /// </remarks>
    public class CreateSprintTaskStatusCommandValidator : AbstractValidator<CreateSprintTaskStatusCommand>
    {
        /// <summary>
        /// Конструктор класса <see cref="CreateSprintTaskStatusCommandValidator"/>.
        /// </summary>
        /// <remarks>
        /// Настраивает правила валидации.
        /// </remarks>
        public CreateSprintTaskStatusCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Наименование обязательно")
                .MaximumLength(50).WithMessage("Наименование не длиннее 50 символов");

            //RuleFor(x => x.Description)
            //    .MaximumLength(200).WithMessage("Описание не длиннее 200 символов");
        }
    }
}
