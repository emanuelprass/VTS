using SceletonAPI.Application.Models.Query;
using System.Collections.Generic;
using System;

namespace SceletonAPI.Application.UseCases.MasterData.Queries.DeliveryOrderList
{
	public class DeliveryOrderListDto : BaseDto
	{
		public List<DeliveryOrderListDtoData> Data { set; get; }
	}

	public class DeliveryOrderListDtoData
	{
		public Int32 ID { set; get; }
		public string DoNumber { set; get; }
		public string DealerName { set; get; }
		public string FinalDestination { set; get; }
		public DateTime RequestDeliveryDate { set; get; }
		public string StorageLocation { set; get; }
		public string Model { set; get; }
		public string ModelDesc { set; get; }
		public string ChassisNo { set; get; }
		public string ManufacturingNumber { set; get; }
		public string SoNumber { set; get; }
	}
}
