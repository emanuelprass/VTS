using MediatR;
using SceletonAPI.Application.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Command.AssignmentCreateUpdate
{
    public class AssignmentCreateUpdateCommand : IRequest<AssignmentCreateUpdateDto>
    {
        public AssignmentCreateUpdateCommandData Data { set; get; }
    }
    
	public class AssignmentCreateUpdateCommandData
    {
		public int? Id { set; get; }
        public string? VendorCode { set; get; }
        public DateTime? ETA { set; get; }
		public ShipData? ShipData { set; get; }
		public List<Batch> Batch { set; get; }
        public string UpdatedBy { set; get; }
    }
	
	public class ShipData
    {
		public string? ShipName { set; get; }
		public string? DeparturePort { set; get; }
		public string? ArrivalPort { set; get; }
		public DateTime? DepartureTime { set; get; }
		public DateTime? ArrivalTime { set; get; }
	}
	
	public class Batch
    {
		public int? BatchId { set; get; }
		public string? DeliveryMode { set; get; }
		public DateTime? PickUpTime { set; get; }
		public string? Timezone { set; get; }
	}
}
