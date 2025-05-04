using FluentValidation;
using PMS.Server.DTOs.ProjectCategoryDTO.Commands;

namespace PMS.Server.Repositories.ProjectCategoryRepository.Handlers.Commands.UpdateProjectCategory
{
    /// <summary>
    /// Валидатор для команды <see cref="UpdateProjectCategoryRequest"/>.
    /// </summary>
    /// <remarks>
    /// Проверяет:
    /// <list type="bullet">
    /// <item><description>Наличие обязательных полей</description></item>
    /// <item><description>Длину наименования (макс. 50 символов)</description></item>
    /// <item><description>Длину описания (макс. 200 символов)</description></item>
    /// </list>
    /// </remarks>
    public class UpdateProjectCategoryCommandValidator : AbstractValidator<UpdateProjectCategoryRequest>
    {
        /// <summary>
        /// Конструктор класса <see cref="UpdateProjectCategoryCommandValidator"/>.
        /// </summary>
        /// <remarks>
        /// Настраивает правила валидации.
        /// </remarks>
        public UpdateProjectCategoryCommandValidator()
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
