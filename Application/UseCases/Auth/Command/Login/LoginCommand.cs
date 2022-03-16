using MediatR;
using SceletonAPI.Application.Models.Query;

namespace SceletonAPI.Application.UseCases.Auth.Command.Login
{
    public class LoginCommand : BaseQueryCommand, IRequest<LoginDto>
    {
        public LoginCommandData Data { set; get; }
    }

    public class LoginCommandData
    {
        public string Email { get; set; }
        public string Password { set; get; }
    }
}
