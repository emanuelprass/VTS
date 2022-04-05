using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SceletonAPI.Application.Interfaces;
using SceletonAPI.Application.Interfaces.Authorization;
using SceletonAPI.Application.Misc;
using SceletonAPI.Application.UseCases.MasterData.Command.AssignmentCreateUpdate;
using SceletonAPI.Application.UseCases.MasterData.Command.AssignmentDelete;
using SceletonAPI.Application.UseCases.MasterData.Queries.AssignmentList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using SceletonAPI.Application.Models.Query;

namespace SceletonAPI.Presenter.Controllers.MasterData.Assignment
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("/assignmentmasterdata")]
    public class AssignmentController : BaseController
    {
        private readonly IAuthUser _authUser;
        private readonly IUploader _logging;
        private readonly Utils _utils;

        public AssignmentController(IAuthUser authUser, IUploader logging, Utils utils)
        {
            _authUser = authUser;
            _logging = logging;
            _utils = utils;

        }
        [HttpPost]
        [Route("/assignmentmasterdata/createupdate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AssignmentCreateUpdateDto>> CreateUpdate([FromBody] AssignmentCreateUpdateCommand Payload)
        {
            Payload.Data.UpdatedBy = _authUser.name;
            var response = await Mediator.Send(Payload);
            return Ok(response);
        }

        [HttpPost]
        [Route("/assignmentmasterdata/delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AssignmentDeleteDto>> Delete([FromBody] AssignmentDeleteCommand Payload)
        {
            Payload.Data.UpdatedBy = _authUser.name;
            var response = await Mediator.Send(Payload);
            return Ok(response);
        }

        [HttpGet]
        [Route("/assignmentmasterdata/list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AssignmentListDto>> List(
            [FromQuery(Name = "page")] int? _Page,
            [FromQuery(Name = "limit")] int? _Limit
            )
        {
            var Query = new AssignmentListQuery
            {
                Page = _Page,
                Limit = _Limit,
                UpdatedBy = _authUser.name
            };			
            return Ok(await Mediator.Send(Query));
        }
    }
}
