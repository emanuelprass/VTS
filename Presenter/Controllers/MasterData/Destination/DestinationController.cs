using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SceletonAPI.Application.Interfaces;
using SceletonAPI.Application.Interfaces.Authorization;
using SceletonAPI.Application.Misc;
using SceletonAPI.Application.UseCases.MasterData.Command.DestinationCreateUpdate;
using SceletonAPI.Application.UseCases.MasterData.Queries.DestinationList;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace SceletonAPI.Presenter.Controllers.MasterData.Destination
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("/destination")]
    public class DestinationController : BaseController
    {
        private readonly IAuthUser _authUser;
        private readonly IUploader _logging;
        private readonly Utils _utils;

        public DestinationController(IAuthUser authUser, IUploader logging, Utils utils)
        {
            _authUser = authUser;
            _logging = logging;
            _utils = utils;

        }

        [HttpPost]
        [Route("/destination/createupdate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DestinationCreateUpdateDto>> CreateUpdate([FromBody] List<CreateDto> Payload)
        {

            foreach (var i in Payload)
            {                
                i.created_by = "SAP_ADMIN";
                i.updated_by = "SAP_ADMIN";
            }

            var response = await Mediator.Send(new DestinationCreateUpdateCommand { data = Payload });
            return Ok(response);
        }

        [HttpGet]
        [Route("/destination/list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DestinationListDto>> List(
            [FromQuery(Name = "page")] int? _Page,
            [FromQuery(Name = "limit")] int? _Limit
            )
        {            
            var Query = new DestinationListQuery
            {
                Page = _Page,
                Limit = _Limit                
            };
            return Ok(await Mediator.Send(Query));
        }
    }
}