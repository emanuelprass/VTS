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
		public int? ShipID { set; get; }
        public string UpdatedBy { set; get; }
    }
}
