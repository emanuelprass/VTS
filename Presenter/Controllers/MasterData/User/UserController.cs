using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SceletonAPI.Application.Interfaces;
using SceletonAPI.Application.Interfaces.Authorization;
using SceletonAPI.Application.Misc;
using SceletonAPI.Application.UseCases.MasterData.Command.UserCreateUpdate;
using SceletonAPI.Application.UseCases.MasterData.Command.UserDelete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace SceletonAPI.Presenter.Controllers.MasterData.User
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("/usermasterdata")]
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
        [Route("/usermasterdata/createupdate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserCreateUpdateDto>> CreateUpdate([FromBody] UserCreateUpdateCommand Payload)
        {
            Payload.Data.UpdatedBy = _authUser.name;
            var response = await Mediator.Send(Payload);
            return Ok(response);
        }

        [HttpPost]
        [Route("/usermasterdata/delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserDeleteDto>> Delete([FromBody] UserDeleteCommand Payload)
        {
            Payload.Data.UpdatedBy = _authUser.name;
            var response = await Mediator.Send(Payload);
            return Ok(response);
        }
    }
}
