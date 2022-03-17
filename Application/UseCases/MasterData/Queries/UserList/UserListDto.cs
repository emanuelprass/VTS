using SceletonAPI.Application.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Queries.UserList
{
    public class UserListDto : BaseDto
    {
        public List<UserListDtoData> Data { set; get; }
    }

    public class UserListDtoData
    {
        public int Id { get; set; }
        public string FullName { set; get; }
        public string Email { set; get; }
        public string Company { set; get; }
        public string Role { set; get; }
        public short Status { set; get; }
        public string CreatedBy { set; get; }
        public string CreatedTime { set; get; }
        public string UpdatedBy { set; get; }
        public string UpdatedTime { set; get; }
    }
}
