using MediatR;
using SceletonAPI.Application.Models.Query;

namespace SceletonAPI.Application.UseCases.MasterData.Queries.DestinationList
{
	public class DestinationListQuery : BaseQueryCommand, IRequest<DestinationListDto>
	{
		public int? Page { set; get; }
		public int? Limit { set; get; }
		public string UpdatedBy { set; get; }
	}
}
