using MediatR;
using SceletonAPI.Application.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Command.DriverDelete
{
    
    public class DriverDeleteCommand : BaseQueryCommand, IRequest<DriverDeleteDto>
    {
        public DriverDeleteCommandData Data { set; get; }
    }
    public class DriverDeleteCommandData
    {
        public int Id { set; get; }
        public string UpdatedBy { set; get; }
    }
}
