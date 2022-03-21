using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SceletonAPI.Application.UseCases.Auth.Command.DriverLogin;

namespace SceletonAPI.Presenter.Controllers.Auth
{
    [Route("authdriver")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class DriverLoginController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DriverLoginDto>> Login([FromBody] DriverLoginCommand Payload)
        {
            return Ok(await Mediator.Send(Payload));
        }
    }
}
