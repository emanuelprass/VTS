using MediatR;
using SceletonAPI.Application.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Command.PricingDelete
{
    
    public class PricingDeleteCommand : BaseQueryCommand, IRequest<PricingDeleteDto>
    {
        public PricingDeleteCommandData Data { set; get; }
    }
    public class PricingDeleteCommandData
    {
        public int Id { set; get; }
        public string UpdatedBy { set; get; }
    }
}
