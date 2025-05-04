using FluentValidation;

namespace PMS.Server.Repositories.DepartmentRepository.Handlers.Commands.CreateDepartment
{
    /// <summary>
    /// Валидатор для команды <see cref="CreateDepartmentCommand"/>.
    /// </summary>
    /// <remarks>
    /// Проверяет:
    /// <list type="bullet">
    /// <item><description>Наличие обязательных полей</description></item>
    /// <item><description>Длину кода (макс. 50 символов)</description></item>
    /// <item><description>Длину наименования (макс. 50 символов)</description></item>
    /// <item><description>Длину описания (макс. 200 символов)</description></item>
    /// </list>
    /// </remarks>
    public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
    {
        /// <summary>
        /// Конструктор класса <see cref="CreateDepartmentCommandValidator"/>.
        /// </summary>
        /// <remarks>
        /// Настраивает правила валидации.
        /// </remarks>
        public CreateDepartmentCommandValidator()
        {
            RuleFor(x => x.Code)
                .MaximumLength(50).WithMessage("Код не длиннее 50 символов");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Наименование обязательно")
                .MaximumLength(50).WithMessage("Наименование не длиннее 50 символов");

            RuleFor(x => x.Description)
                .MaximumLength(200).WithMessage("Описание не длиннее 200 символов");
        }
    }
}
