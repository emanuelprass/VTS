using MediatR;
using SceletonAPI.Application.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Queries.CarpoolList
{
    
    public class CarpoolListQuery : BaseQueryCommand, IRequest<CarpoolListDto>
    {
        public int? Page { set; get; }
        public int? Limit { set; get; }
    }
}
