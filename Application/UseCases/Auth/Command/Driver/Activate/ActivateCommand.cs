using MediatR;
using SceletonAPI.Application.Models.Query;

namespace SceletonAPI.Application.UseCases.Auth.Command.Driver.Activate
{
    public class ActivateCommand : BaseQueryCommand, IRequest<ActivateDto>
    {
        public ActivateCommandData Data { set; get; }
    }

    public class ActivateCommandData
    {
        public string Phone { get; set; }
        public int OTP { set; get; }
    }
}
