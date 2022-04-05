using SceletonAPI.Application.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Queries.AssignmentList
{
    public class AssignmentListDto : BaseDto
    {
        public AssignmentListDtoMeta Meta { set; get; }
        public List<AssignmentListDtoData> Data { set; get; }
    }

    public class AssignmentListDtoMeta
    {
        public int? Page { get; set; }
        public int? Limit { get; set; }
        public int TotalData { get; set; }
        public int TotalPage { get; set; }
    }

    public class AssignmentListDtoData
    {
        public int ID { set; get; }
        public string? VendorName { set; get; }
        public DateTime? ETA { set; get; }
		public int? ShipID { set; get; }
	}
}
