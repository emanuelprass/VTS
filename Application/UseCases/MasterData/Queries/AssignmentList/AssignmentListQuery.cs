using MediatR;
using SceletonAPI.Application.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Queries.AssignmentList
{
    
    public class AssignmentListQuery : BaseQueryCommand, IRequest<AssignmentListDto>
    {
        public int? Page { set; get; }
        public int? Limit { set; get; }
        public string UpdatedBy { set; get; }
    }
}
