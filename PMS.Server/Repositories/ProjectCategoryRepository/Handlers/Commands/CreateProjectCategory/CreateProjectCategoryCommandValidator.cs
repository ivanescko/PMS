using FluentValidation;

namespace PMS.Server.Repositories.ProjectCategoryRepository.Handlers.Commands.CreateProjectCategory
{
    /// <summary>
    /// Валидатор для команды <see cref="CreateProjectCategoryCommand"/>.
    /// </summary>
    /// <remarks>
    /// Проверяет:
    /// <list type="bullet">
    /// <item><description>Наличие обязательных полей</description></item>
    /// <item><description>Длину наименования (макс. 50 символов)</description></item>
    /// <item><description>Длину описания (макс. 200 символов)</description></item>
    /// </list>
    /// </remarks>
    public class CreateProjectCategoryCommandValidator : AbstractValidator<CreateProjectCategoryCommand>
    {
        /// <summary>
        /// Конструктор класса <see cref="CreateProjectCategoryCommandValidator"/>.
        /// </summary>
        /// <remarks>
        /// Настраивает правила валидации.
        /// </remarks>
        public CreateProjectCategoryCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Наименование обязательно")
                .MaximumLength(50).WithMessage("Наименование не длиннее 50 символов");

            RuleFor(x => x.Description)
                .MaximumLength(200).WithMessage("Описание не длиннее 200 символов");
        }
    }
}
