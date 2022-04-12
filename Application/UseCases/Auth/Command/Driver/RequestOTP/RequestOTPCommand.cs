using MediatR;
using SceletonAPI.Application.Models.Query;

namespace SceletonAPI.Application.UseCases.Auth.Command.Driver.RequestOTP
{
    public class RequestOTPCommand : BaseQueryCommand, IRequest<RequestOTPDto>
    {
        public RequestOTPCommandData Data { set; get; }
    }

    public class RequestOTPCommandData
    {
        public string Phone { get; set; }
    }
}
