using MediatR;
using SceletonAPI.Application.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Command.UserList
{
    
    public class UserListCommand : BaseQueryCommand, IRequest<UserListDto>
    {
        public UserListCommandData Data { set; get; }
    }
    public class UserListCommandData
    {
        public int ID { set; get; }
        public string UpdatedBy { set; get; }
    }
}
