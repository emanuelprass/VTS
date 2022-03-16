using FluentValidation;

namespace SceletonAPI.Application.UseCases.Auth.Command.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {

        }
    }
}
