using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Domain.Entities
{
    public class MasterDataPricing
    {
        public int ID { set; get; }
        public string Region { set; get; }
        public int DestinationID { set; get; }
        public long VendorID { set; get; }
		public int FleetID { set; get; }
		public long Price { set; get; }
		public int TransportModeID { set; get; }
        public string CreatedBy { set; get; }
        public DateTime CreatedTime { set; get; }
        public string UpdatedBy { set; get; }
        public DateTime UpdatedTime { set; get; }
    }
}
