using MediatR;
using SceletonAPI.Application.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Command.VendorDelete
{
	public class VendorDeleteCommand : BaseQueryCommand, IRequest<VendorDeleteDto>
	{
		public VendorDeleteCommandData Data { set; get; }
	}

	public class VendorDeleteCommandData
	{
		public int ID { set; get; }
		public string UpdatedBy { set; get; }
	}
}
