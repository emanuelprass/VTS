using SceletonAPI.Application.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Queries.UserList
{
    public class UserListDto : BaseDto
    {
        public UserListDtoMeta Meta { set; get; }
        public List<UserListDtoData> Data { set; get; }
    }

    public class UserListDtoMeta
    {
        public int? Page { get; set; }
        public int? Limit { get; set; }
        public int TotalData { get; set; }
        public int TotalPage { get; set; }
    }

    public class UserListDtoData
    {
        public int Id { get; set; }
        public string FullName { set; get; }
        public string Email { set; get; }
        public string Company { set; get; }
        public string Role { set; get; }
        public string VendorName { set; get; }
        public string CreatedBy { set; get; }
        public DateTime CreatedTime { set; get; }
        public string UpdatedBy { set; get; }
        public DateTime UpdatedTime { set; get; }
    }
}
