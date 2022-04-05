using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Domain.Entities
{
    public class MasterDataAssignment
    {
        public int ID { set; get; }
        public int VendorID { set; get; }
		public DateTime ETA { set; get; }
		public int ShipID { set; get; }
        public string CreatedBy { set; get; }
        public DateTime CreatedTime { set; get; }
        public string UpdatedBy { set; get; }
        public DateTime UpdatedTime { set; get; }
		public string Message { set; get; }
    }
}
