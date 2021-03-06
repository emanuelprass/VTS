using MediatR;
using SceletonAPI.Application.Models.Query;

namespace SceletonAPI.Application.UseCases.MasterData.Queries.DeliveryOrderList
{
	public class DeliveryOrderListQuery : BaseQueryCommand, IRequest<DeliveryOrderListDto>
	{
		public int? Page { set; get; }
		public int? Limit { set; get; }
		public string Key { set; get; }
		public string Value { set; get; }
		public string UpdatedBy { set; get; }
	}
}
