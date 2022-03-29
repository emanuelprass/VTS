using MediatR;
using SceletonAPI.Application.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Command.PricingCreateUpdate
{
    public class PricingCreateUpdateCommand : IRequest<PricingCreateUpdateDto>
    {
        public List<CreateDto> Data { set; get; }
    }
    public class CreateDto
    {
        public string Region { set; get; }
        public int DestinationCode { set; get; }
        public string SoldToParty { set; get; }
        public string City { set; get; }
        public string VendorCode { set; get; }
        public string Vendor { set; get; }
        public string CarModel { set; get; }
		public long Price { set; get; }
		public string DeliveryMode { set; get; }
        public string UpdatedBy { set; get; }
    }
}
