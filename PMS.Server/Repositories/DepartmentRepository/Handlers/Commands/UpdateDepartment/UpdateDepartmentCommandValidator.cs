using FluentValidation;
using PMS.Server.DTOs.DepartmentDTO.Commands;

namespace PMS.Server.Repositories.DepartmentRepository.Handlers.Commands.UpdateDepartment
{
    /// <summary>
    /// Валидатор для команды <see cref="UpdateDepartmentRequest"/>.
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
    public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentRequest>
    {
        /// <summary>
        /// Конструктор класса <see cref="UpdateDepartmentCommandValidator"/>.
        /// </summary>
        /// <remarks>
        /// Настраивает правила валидации.
        /// </remarks>
        public UpdateDepartmentCommandValidator()
        {
            RuleFor(x => x.Code)
                .MaximumLength(50).When(x => x.Code != null)
                .WithMessage("Код не длиннее 50 символов");

            RuleFor(x => x.Title)
                .MaximumLength(50).When(x => x.Title != null)
                .WithMessage("Наименование не длиннее 50 символов");

            RuleFor(x => x.Description)
                .MaximumLength(200).When(x => x.Description != null)
                .WithMessage("Описание не длиннее 200 символов");
        }
    }
}
