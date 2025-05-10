using FluentValidation;

namespace PMS.Server.Repositories.AuthenticationRepository.Handlers.Commands
{
    /// <summary>
    /// Валидатор для команды <see cref="LoginCommand"/>.
    /// </summary>
    /// <remarks>
    /// Проверяет:
    /// <list type="bullet">
    /// <item><description>Наличие обязательных полей</description></item>
    /// <item><description>Длину логина (макс. 50 символов)</description></item>
    /// <item><description>Длину пароля (мин. 8 символов)</description></item>
    /// </list>
    /// </remarks>
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        /// <summary>
        /// Конструктор класса <see cref="LoginCommandValidator"/>.
        /// </summary>
        /// <remarks>
        /// Настраивает правила валидации.
        /// </remarks>
        public LoginCommandValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty().WithMessage("Логин обязателен")
                .MaximumLength(50).WithMessage("Логин не длиннее 50 символов");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Пароль обязателен")
                .MinimumLength(8).WithMessage("Пароль минимум 8 символов");
        }
    }
}
