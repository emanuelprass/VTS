using FluentValidation;

namespace SceletonAPI.Application.UseCases.Auth.Command.Driver.RequestOTP
{
    public class RequestOTPCommandValidator : AbstractValidator<RequestOTPCommand>
    {
        public RequestOTPCommandValidator()
        {
            RuleFor(request => request.Data.Phone).NotEmpty();
        }
    }
}
