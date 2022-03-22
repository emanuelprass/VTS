using MediatR;
using SceletonAPI.Application.Models.Query;

namespace SceletonAPI.Application.UseCases.MasterData.Queries.VendorList
{
	public class VendorListQuery : BaseQueryCommand, IRequest<VendorListDto>
	{
		public int? Page { set; get; }
		public int? Limit { set; get; }
		public string UpdatedBy { set; get; }
	}
}
