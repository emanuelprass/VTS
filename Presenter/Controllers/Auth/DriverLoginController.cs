using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SceletonAPI.Application.UseCases.Auth.Command.Driver.Login;
using SceletonAPI.Application.UseCases.Auth.Command.Driver.RequestOTP;
using SceletonAPI.Application.UseCases.Auth.Command.Driver.Activate;

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
		
		[HttpPost]
        [Route("/authdriver/requestotp")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<RequestOTPDto>> RequestOTP([FromBody] RequestOTPCommand Payload)
        {
            var response = await Mediator.Send(Payload);
            return Ok(response);
        }
		
		[HttpPost]
        [Route("/authdriver/activation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ActivateDto>> Activation([FromBody] ActivateCommand Payload)
        {
            var response = await Mediator.Send(Payload);
            return Ok(response);
        }
    }
}
