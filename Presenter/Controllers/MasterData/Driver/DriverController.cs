using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SceletonAPI.Application.Interfaces;
using SceletonAPI.Application.Interfaces.Authorization;
using SceletonAPI.Application.Misc;
using SceletonAPI.Application.UseCases.MasterData.Command.DriverCreateUpdate;
using SceletonAPI.Application.UseCases.MasterData.Command.DriverDelete;
using SceletonAPI.Application.UseCases.MasterData.Queries.DriverList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using SceletonAPI.Application.Models.Query;

namespace SceletonAPI.Presenter.Controllers.MasterData.Driver
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("/drivermasterdata")]
    public class DriverController : BaseController
    {
        private readonly IAuthUser _authUser;
        private readonly IUploader _logging;
        private readonly Utils _utils;

        public DriverController(IAuthUser authUser, IUploader logging, Utils utils)
        {
            _authUser = authUser;
            _logging = logging;
            _utils = utils;

        }
        [HttpPost]
        [Route("/drivermasterdata/createupdate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DriverCreateUpdateDto>> CreateUpdate([FromBody] DriverCreateUpdateCommand Payload)
        {
            Payload.Data.UpdatedBy = _authUser.name;
            var response = await Mediator.Send(Payload);
            return Ok(response);
        }

        [HttpPost]
        [Route("/drivermasterdata/delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DriverDeleteDto>> Delete([FromBody] DriverDeleteCommand Payload)
        {
            Payload.Data.UpdatedBy = _authUser.name;
            var response = await Mediator.Send(Payload);
            return Ok(response);
        }

        [HttpGet]
        [Route("/drivermasterdata/list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DriverListDto>> List(
            [FromQuery(Name = "page")] int? _Page,
            [FromQuery(Name = "limit")] int? _Limit
            )
        {
            var Query = new DriverListQuery
            {
                Page = _Page,
                Limit = _Limit,
                UpdatedBy = _authUser.name
            };
            return Ok(await Mediator.Send(Query));
        }
    }
}
