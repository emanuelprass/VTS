using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SceletonAPI.Application.UseCases.Auth.Command.Login;

namespace SceletonAPI.Presenter.Controllers.Auth
{
    [Route("auth")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class LoginController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<LoginDto>> Login([FromBody] LoginCommand Payload)
        {
            return Ok(await Mediator.Send(Payload));
        }
    }
}
