using MediatR;
using SceletonAPI.Application.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Command.UserDelete
{
    
    public class UserDeleteCommand : BaseQueryCommand, IRequest<UserDeleteDto>
    {
        public UserDeleteCommandData Data { set; get; }
    }
    public class UserDeleteCommandData
    {
        public int ID { set; get; }
        public string UpdatedBy { set; get; }
    }
}
