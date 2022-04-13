using SceletonAPI.Application.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Queries.CarpoolList
{
    public class CarpoolListDto : BaseDto
    {
        public CarpoolListDtoMeta Meta { set; get; }
        public List<CarpoolListDtoData> Data { set; get; }
    }

    public class CarpoolListDtoMeta
    {
        public int? Page { get; set; }
        public int? Limit { get; set; }
        public int TotalData { get; set; }
        public int TotalPage { get; set; }
    }

    public class CarpoolListDtoData
    {
        public int ID { set; get; }
        public string CarpoolName { set; get; }
        public string Timezone { set; get; }
        public string CapacityCC { set; get; }
        public string CapacityTW { set; get; }
	}
}
