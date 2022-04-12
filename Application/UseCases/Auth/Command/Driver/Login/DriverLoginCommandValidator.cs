using FluentValidation;

namespace SceletonAPI.Application.UseCases.Auth.Command.Driver.Login
{
    public class DriverLoginCommandValidator : AbstractValidator<DriverLoginCommand>
    {
        public DriverLoginCommandValidator()
        {
            RuleFor(login => login.Data.Phone).NotEmpty();
            RuleFor(login => login.Data.Password).NotEmpty();
        }
    }
}
