using MediatR;
using SceletonAPI.Application.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Queries.UserList
{
    
    public class UserListQuery : BaseQueryCommand, IRequest<UserListDto>
    {
        public int? Page { set; get; }
        public int? Limit { set; get; }
        public string UpdatedBy { set; get; }
    }
}
