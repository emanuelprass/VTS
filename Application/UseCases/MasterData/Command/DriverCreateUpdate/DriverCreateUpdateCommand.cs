using MediatR;
using SceletonAPI.Application.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Command.DriverCreateUpdate
{
    public class DriverCreateUpdateCommand : BaseQueryCommand, IRequest<DriverCreateUpdateDto>
    {
        public DriverCreateUpdateCommandData Data { set; get; }
    }
    public class DriverCreateUpdateCommandData
    {
        public int? Id { get; set; }
        public string FullName { set; get; }
        public string Phone { set; get; }
        public string VendorName { set; get; }
        public string Password { set; get; }
        public string ConfPassword { set; get; }
        public string UpdatedBy { set; get; }

    }
}
