using FluentValidation;

namespace SceletonAPI.Application.UseCases.Auth.Command.Driver.Activate
{
    public class ActivateCommandValidator : AbstractValidator<ActivateCommand>
    {
        public ActivateCommandValidator()
        {
            RuleFor(activation => activation.Data.Phone).NotEmpty();
            RuleFor(activation => activation.Data.OTP).NotEmpty();
        }
    }
}
