using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SceletonAPI.Application.Interfaces;
using SceletonAPI.Application.Interfaces.Authorization;
using SceletonAPI.Application.Misc;
using SceletonAPI.Application.UseCases.MasterData.Command.PricingCreateUpdate;
using SceletonAPI.Application.UseCases.MasterData.Command.PricingDelete;
using SceletonAPI.Application.UseCases.MasterData.Queries.PricingList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using SceletonAPI.Application.Models.Query;

namespace SceletonAPI.Presenter.Controllers.MasterData.Pricing
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("/pricingmasterdata")]
    public class PricingController : BaseController
    {
        private readonly IAuthUser _authUser;
        private readonly IUploader _logging;
        private readonly Utils _utils;

        public PricingController(IAuthUser authUser, IUploader logging, Utils utils)
        {
            _authUser = authUser;
            _logging = logging;
            _utils = utils;

        }
        [HttpPost]
        [Route("/pricingmasterdata/createupdate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PricingCreateUpdateDto>> CreateUpdate([FromBody] PricingCreateUpdateCommand Payload)
        {
            Payload.Data.UpdatedBy = _authUser.name;
            var response = await Mediator.Send(Payload);
            return Ok(response);
        }

        [HttpPost]
        [Route("/pricingmasterdata/delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PricingDeleteDto>> Delete([FromBody] PricingDeleteCommand Payload)
        {
            Payload.Data.UpdatedBy = _authUser.name;
            var response = await Mediator.Send(Payload);
            return Ok(response);
        }

        [HttpGet]
        [Route("/pricingmasterdata/list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PricingListDto>> List(
            [FromQuery(Name = "page")] int? _Page,
            [FromQuery(Name = "limit")] int? _Limit
            )
        {
            var Query = new PricingListQuery
            {
                Page = _Page,
                Limit = _Limit,
                UpdatedBy = _authUser.name
            };			
            return Ok(await Mediator.Send(Query));
        }
    }
}
