using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SceletonAPI.Application.Interfaces;
using SceletonAPI.Application.Interfaces.Authorization;
using SceletonAPI.Application.Misc;
using SceletonAPI.Application.UseCases.MasterData.Command.DeliveryOrderCreateUpdate;
using SceletonAPI.Application.UseCases.MasterData.Queries.DeliveryOrderList;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace SceletonAPI.Presenter.Controllers.DeliveryOrder
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("/DeliveryOrder")]
    public class DeliveryOrderController : BaseController
    {
        private readonly IAuthUser _authUser;
        private readonly IUploader _logging;
        private readonly Utils _utils;

        public DeliveryOrderController(IAuthUser authUser, IUploader logging, Utils utils)
        {
            _authUser = authUser;
            _logging = logging;
            _utils = utils;

        }

        [HttpPost]
        [Route("/deliveryorder/createupdate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DeliveryOrderCreateUpdateDto>> CreateUpdate([FromBody] List<CreateDto> Payload)
        {

            foreach (var i in Payload)
            {                
                i.created_by = "SAP_ADMIN";
                i.updated_by = "SAP_ADMIN";
            }

            var response = await Mediator.Send(new DeliveryOrderCreateUpdateCommand { data = Payload });
            return Ok(response);
        }

        [HttpGet]
        [Route("/deliveryorder/list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DeliveryOrderListDtoData>> List(
            [FromQuery(Name = "page")] int? _Page,
            [FromQuery(Name = "limit")] int? _Limit
            )
        {            
            var Query = new DeliveryOrderListQuery
            {
                Page = _Page,
                Limit = _Limit                
            };
            return Ok(await Mediator.Send(Query));
        }

        // [HttpPost]
        // [Route("/DeliveryOrder/delete")]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // public async Task<ActionResult<DeliveryOrderDeleteDto>> Delete([FromBody] DeliveryOrderDeleteCommand Payload)
        // {
        //     Payload.Data.UpdatedBy = _authUser.name;
        //     var response = await Mediator.Send(Payload);
        //     return Ok(response);
        // }

        

    }
}
