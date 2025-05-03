using FluentValidation;
using PMS.Server.DTOs.UserDTO.Commands;

namespace PMS.Server.Repositories.UserRepository.Handlers.Commands.UpdateUser
{
    /// <summary>
    /// Валидатор для команды <see cref="UpdateUserRequest"/>.
    /// </summary>
    /// <remarks>
    /// Проверяет:
    /// <list type="bullet">
    /// <item><description>Длину логина (макс. 50 символов)</description></item>
    /// <item><description>Длину пароля (мин. 8 символов)</description></item>
    /// </list>
    /// </remarks>
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserRequest>
    {
        /// <summary>
        /// Конструктор класса <see cref="UpdateUserCommandValidator"/>.
        /// </summary>
        /// <remarks>
        /// Настраивает правила валидации.
        /// </remarks>
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Login)
                .MaximumLength(50).When(x => x.Login != null)
                .WithMessage("Логин не длиннее 50 символов");

            RuleFor(x => x.Password)
                .MinimumLength(8).When(x => x.Password != null)
                .WithMessage("Пароль минимум 8 символов");
        }
    }
}
