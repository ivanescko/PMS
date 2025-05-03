using FluentValidation;

namespace PMS.Server.Repositories.SpecialityRepository.Handlers.Commands.CreateSpeciality
{
    /// <summary>
    /// Валидатор для команды <see cref="CreateSpecialityCommand"/>.
    /// </summary>
    /// <remarks>
    /// Проверяет:
    /// <list type="bullet">
    /// <item><description>Наличие обязательных полей</description></item>
    /// <item><description>Длину наименования (макс. 50 символов)</description></item>
    /// </list>
    /// </remarks>
    public class CreateSpecialityCommandValidator : AbstractValidator<CreateSpecialityCommand>
    {
        /// <summary>
        /// Конструктор класса <see cref="CreateSpecialityCommandValidator"/>.
        /// </summary>
        /// <remarks>
        /// Настраивает правила валидации.
        /// </remarks>
        public CreateSpecialityCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Наименование обязательно")
                .MaximumLength(50).WithMessage("Наименование не длиннее 50 символов");
        }
    }
}
