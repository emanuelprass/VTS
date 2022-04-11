using MediatR;
using SceletonAPI.Application.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Queries.DriverList
{
    
    public class DriverListQuery : BaseQueryCommand, IRequest<DriverListDto>
    {
        public int? Page { set; get; }
        public int? Limit { set; get; }
        public string Token { set; get; }
        public string Company { set; get; }
    }
}
