using MediatR;
using SceletonAPI.Application.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Command.AssignmentDelete
{
    
    public class AssignmentDeleteCommand : BaseQueryCommand, IRequest<AssignmentDeleteDto>
    {
        public AssignmentDeleteCommandData Data { set; get; }
    }
    public class AssignmentDeleteCommandData
    {
        public int Id { set; get; }
        public string UpdatedBy { set; get; }
    }
}
