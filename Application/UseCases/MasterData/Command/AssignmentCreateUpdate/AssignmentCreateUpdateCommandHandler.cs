using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoredProcedureEFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using SceletonAPI.Application.UseCases.MasterData.Command.AssignmentCreateUpdate;
using SceletonAPI.Application.Interfaces;
using SceletonAPI.Domain.Entities;

namespace SceletonAPI.Application.UseCases.MasterData.Command.AssignmentCreateUpdate
{
    public class AssignmentCreateUpdateCommandHandler : IRequestHandler<AssignmentCreateUpdateCommand, AssignmentCreateUpdateDto>
    {
        private readonly IVTSDBContext _context;
        private readonly IMapper _mapper;

        public AssignmentCreateUpdateCommandHandler(IVTSDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AssignmentCreateUpdateDto> Handle(AssignmentCreateUpdateCommand request, CancellationToken cancellationToken)
        {
            var response = new AssignmentCreateUpdateDto();
            var data = new AssignmentCreateUpdateDtoData();
			List<MasterDataAssignment> spinsertAssignment = null;
            _context.loadStoredProcedureBuilder("SP_InsertUpdate_AssignmentMasterData")
				.AddParam("ID", request.Data.Id.HasValue ? request.Data.Id : 0)
                .AddParam("VendorCode", request.Data.VendorCode)
                .AddParam("ETA", request.Data.ETA)
                .AddParam("ShipName", request.Data.ShipData != null ? request.Data.ShipData.ShipName : null)
                .AddParam("DeparturePort", request.Data.ShipData != null ? request.Data.ShipData.DeparturePort : null)
                .AddParam("ArrivalPort", request.Data.ShipData != null ? request.Data.ShipData.ArrivalPort : null)
				.AddParam("DepartureTime", request.Data.ShipData != null ? request.Data.ShipData.DepartureTime : null)
                .AddParam("ArrivalTime", request.Data.ShipData != null ? request.Data.ShipData.ArrivalTime : null)
                .AddParam("UpdatedBy", request.Data.UpdatedBy)
                .Exec(r => spinsertAssignment = r.ToList<MasterDataAssignment>());

			if (spinsertAssignment.Any())
			{
				foreach (var result in spinsertAssignment)
				{
					if (result.Message != null)
					{
					response.Success = true;
					response.Message = result.Message;
					
					return response;
					}
				data.Id = (Convert.ToInt32(result.ID));
				}
			}
			response.Data = data;
            response.Success = true;
            response.Message = "Assignment berhasil dibuat atau diupdate";
            
            return response;
        }
    }
}
