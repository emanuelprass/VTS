using FluentValidation;

namespace SceletonAPI.Application.UseCases.Auth.Command.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(login => login.Data.Email).NotEmpty();
            RuleFor(login => login.Data.Password).NotEmpty();
        }
    }
}
