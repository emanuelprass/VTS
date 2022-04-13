using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SceletonAPI.Application.Interfaces;
using SceletonAPI.Application.Interfaces.Authorization;
using SceletonAPI.Application.Misc;
using SceletonAPI.Application.UseCases.MasterData.Queries.CarpoolList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using SceletonAPI.Application.Models.Query;

namespace SceletonAPI.Presenter.Controllers.MasterData.Carpool
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("/carpoolmasterdata")]
    public class CarpoolController : BaseController
    {
        private readonly IAuthUser _authUser;
        private readonly IUploader _logging;
        private readonly Utils _utils;

        public CarpoolController(IAuthUser authUser, IUploader logging, Utils utils)
        {
            _authUser = authUser;
            _logging = logging;
            _utils = utils;
        }

        [HttpGet]
        [Route("/carpoolmasterdata/list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CarpoolListDto>> List(
            [FromQuery(Name = "page")] int? _Page,
            [FromQuery(Name = "limit")] int? _Limit
            )
        {
            var Query = new CarpoolListQuery
            {
                Page = _Page,
                Limit = _Limit,
            };
            return Ok(await Mediator.Send(Query));
        }
    }
}
