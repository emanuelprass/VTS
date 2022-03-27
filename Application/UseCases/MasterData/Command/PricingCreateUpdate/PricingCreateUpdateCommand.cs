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
        public string Region { set; get; }
        public int DestinationCode { set; get; }
        public string VendorCode { set; get; }
		public string ModelName { set; get; }
		public long Price { set; get; }
		public string DeliveryMode { set; get; }
        public string UpdatedBy { set; get; }
    }
}
