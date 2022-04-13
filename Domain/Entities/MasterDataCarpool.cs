using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Domain.Entities
{
    public class MasterDataCarpool
    {
        public int ID { set; get; }
        public string CarpoolName { set; get; }
        public string Time { set; get; }
        public string CapacityCC { set; get; }
        public string CapacityTW { set; get; }
        public short RowStatus { set; get; }
        public string CreatedBy { set; get; }
        public DateTime CreatedTime { set; get; }
        public string UpdatedBy { set; get; }
        public DateTime UpdatedTime { set; get; }
		public string Message { set; get; }
    }
}
