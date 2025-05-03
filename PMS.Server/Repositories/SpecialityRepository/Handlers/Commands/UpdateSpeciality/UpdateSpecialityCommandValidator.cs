using FluentValidation;
using PMS.Server.DTOs.SpecialityDTO.Commands;

namespace PMS.Server.Repositories.SpecialityRepository.Handlers.Commands.UpdateSpeciality
{
    /// <summary>
    /// Валидатор для команды <see cref="UpdateSpecialityRequest"/>.
    /// </summary>
    /// <remarks>
    /// Проверяет:
    /// <list type="bullet">
    /// <item><description>Наличие обязательных полей</description></item>
    /// <item><description>Длину наименования (макс. 50 символов)</description></item>
    /// </list>
    /// </remarks>
    public class UpdateSpecialityCommandValidator : AbstractValidator<UpdateSpecialityRequest>
    {
        /// <summary>
        /// Конструктор класса <see cref="UpdateSpecialityCommandValidator"/>.
        /// </summary>
        /// <remarks>
        /// Настраивает правила валидации.
        /// </remarks>
        public UpdateSpecialityCommandValidator()
        {
            RuleFor(x => x.Title)
                .MaximumLength(50).When(x => x.Title != null)
                .WithMessage("Наименование не длиннее 50 символов");
        }
    }
}
