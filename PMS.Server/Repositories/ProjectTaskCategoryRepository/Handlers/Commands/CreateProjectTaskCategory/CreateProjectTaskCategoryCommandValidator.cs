using FluentValidation;

namespace PMS.Server.Repositories.ProjectTaskCategoryRepository.Handlers.Commands.CreateProjectTaskCategory
{
    /// <summary>
    /// Валидатор для команды <see cref="CreateProjectTaskCategoryCommand"/>.
    /// </summary>
    /// <remarks>
    /// Проверяет:
    /// <list type="bullet">
    /// <item><description>Наличие обязательных полей</description></item>
    /// <item><description>Длину наименования (макс. 50 символов)</description></item>
    /// <item><description>Длину описания (макс. 200 символов)</description></item>
    /// </list>
    /// </remarks>
    public class CreateProjectTaskCategoryCommandValidator : AbstractValidator<CreateProjectTaskCategoryCommand>
    {
        /// <summary>
        /// Конструктор класса <see cref="CreateProjectTaskCategoryCommandValidator"/>.
        /// </summary>
        /// <remarks>
        /// Настраивает правила валидации.
        /// </remarks>
        public CreateProjectTaskCategoryCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Наименование обязательно")
                .MaximumLength(50).WithMessage("Наименование не длиннее 50 символов");

            RuleFor(x => x.Description)
                .MaximumLength(200).WithMessage("Описание не длиннее 200 символов");
        }
    }
}
