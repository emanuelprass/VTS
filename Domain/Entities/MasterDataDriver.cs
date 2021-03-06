using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Domain.Entities
{
    public class MasterDataDriver
    {
        public int ID { set; get; }
        public string FullName { set; get; }
        public string Phone { set; get; }
        public long VendorID { set; get; }
        public short Status { set; get; }
        public string Password { set; get; }
        public string ConfPassword { set; get; }
        public short RowStatus { set; get; }
        public string CreatedBy { set; get; }
        public DateTime CreatedTime { set; get; }
        public string LastUpdatedBy { set; get; }
        public DateTime LastUpdatedTime { set; get; }
		public string Message { set; get; }
    }
}
