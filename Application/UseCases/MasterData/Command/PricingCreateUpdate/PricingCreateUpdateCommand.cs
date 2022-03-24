using MediatR;
using SceletonAPI.Application.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Command.PricingCreateUpdate
{
    public class PricingCreateUpdateCommand : BaseQueryCommand, IRequest<PricingCreateUpdateDto>
    {
        public PricingCreateUpdateCommandData Data { set; get; }
    }
    public class PricingCreateUpdateCommandData
    {
        public int? Id { get; set; }
        public string? Region { set; get; }
        public int? DestinationId { set; get; }
        public string? VendorId { set; get; }
		public int? FleetId { set; get; }
		public long? Price { set; get; }
		public int? TransportModeId { set; get; }
        public string UpdatedBy { set; get; }
    }
}
