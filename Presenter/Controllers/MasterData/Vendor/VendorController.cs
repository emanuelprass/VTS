using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SceletonAPI.Application.Interfaces;
using SceletonAPI.Application.Interfaces.Authorization;
using SceletonAPI.Application.Misc;
using SceletonAPI.Application.UseCases.MasterData.Command.VendorCreateUpdate;
using SceletonAPI.Application.UseCases.MasterData.Command.VendorDelete;
using SceletonAPI.Application.UseCases.MasterData.Queries.VendorList;
using System.Net.Mime;
using System.Threading.Tasks;

namespace SceletonAPI.Presenter.Controllers.MasterData.Vendor
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("/vendor")]
    public class UserController : BaseController
    {
        private readonly IAuthUser _authUser;
        private readonly IUploader _logging;
        private readonly Utils _utils;

        public UserController(IAuthUser authUser, IUploader logging, Utils utils)
        {
            _authUser = authUser;
            _logging = logging;
            _utils = utils;

        }
        [HttpPost]
        [Route("/vendor/createupdate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VendorCreateUpdateDto>> CreateUpdate([FromBody] VendorCreateUpdateCommand Payload)
        {
            Payload.UpdatedBy = _authUser.name;
            Payload.CreatedBy = _authUser.name;			
            
            var response = await Mediator.Send(Payload);
            return Ok(response);
        }

        [HttpGet]
        [Route("/vendor/list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VendorListDto>> List(
            [FromQuery(Name = "page")] int? _Page,
            [FromQuery(Name = "limit")] int? _Limit
            )
        {            
            var Query = new VendorListQuery
            {
                Page = _Page,
                Limit = _Limit                
            };
            return Ok(await Mediator.Send(Query));
        }

        [HttpPost]
        [Route("/vendor/delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VendorDeleteDto>> Delete([FromBody] VendorDeleteCommand Payload)
        {
            Payload.Data.UpdatedBy = _authUser.name;
            var response = await Mediator.Send(Payload);
            return Ok(response);
        }

    }
}
