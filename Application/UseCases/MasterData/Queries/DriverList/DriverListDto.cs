using SceletonAPI.Application.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Queries.DriverList
{
    public class DriverListDto : BaseDto
    {
        public DriverListDtoMeta Meta { set; get; }
        public List<DriverListDtoData> Data { set; get; }
    }

    public class DriverListDtoMeta
    {
        public int? Page { get; set; }
        public int? Limit { get; set; }
        public int TotalData { get; set; }
        public int TotalPage { get; set; }
    }

    public class DriverListDtoData
    {
        public int Id { get; set; }
        public string FullName { set; get; }
        public string Phone { set; get; }
        public string VendorName { set; get; }
		public short Status { set; get; }
        public string CreatedBy { set; get; }
        public DateTime CreatedTime { set; get; }
        public string UpdatedBy { set; get; }
        public DateTime UpdatedTime { set; get; }
    }
}
