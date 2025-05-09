using FluentValidation;
using PMS.Server.DTOs.ProjectTaskCategoryDTO.Commands;

namespace PMS.Server.Repositories.ProjectTaskCategoryRepository.Handlers.Commands.UpdateProjectTaskCategory
{
    /// <summary>
    /// Валидатор для команды <see cref="UpdateProjectTaskCategoryRequest"/>.
    /// </summary>
    /// <remarks>
    /// Проверяет:
    /// <list type="bullet">
    /// <item><description>Наличие обязательных полей</description></item>
    /// <item><description>Длину наименования (макс. 50 символов)</description></item>
    /// <item><description>Длину описания (макс. 200 символов)</description></item>
    /// </list>
    /// </remarks>
    public class UpdateProjectTaskCategoryCommandValidator : AbstractValidator<UpdateProjectTaskCategoryRequest>
    {
        /// <summary>
        /// Конструктор класса <see cref="UpdateProjectTaskCategoryCommandValidator"/>.
        /// </summary>
        /// <remarks>
        /// Настраивает правила валидации.
        /// </remarks>
        public UpdateProjectTaskCategoryCommandValidator()
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
