using FluentValidation;

namespace SceletonAPI.Application.UseCases.Auth.Command.DriverLogin
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
