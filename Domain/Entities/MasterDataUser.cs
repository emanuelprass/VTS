using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Domain.Entities
{
    public class MasterDataUser
    {
        public int ID { set; get; }
        public string FullName { set; get; }
        public string Email { set; get; }
        public string Company { set; get; }
        public string VendorName { set; get; }
        public string UserRole { set; get; }
        public string Password { set; get; }
        public string ConfPassword { set; get; }
        public Int16 RowStatus { set; get; }
        public string CreatedBy { set; get; }
        public DateTime CreatedTime { set; get; }
        public string LastUpdatedBy { set; get; }
        public DateTime LastUpdatedTime { set; get; }
    }
}
