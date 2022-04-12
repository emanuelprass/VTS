using MediatR;
using SceletonAPI.Application.Models.Query;

namespace SceletonAPI.Application.UseCases.Auth.Command.Driver.Login
{
    public class DriverLoginCommand : BaseQueryCommand, IRequest<DriverLoginDto>
    {
        public DriverLoginCommandData Data { set; get; }
    }

    public class DriverLoginCommandData
    {
        public string Phone { get; set; }
        public string Password { set; get; }
    }
}
