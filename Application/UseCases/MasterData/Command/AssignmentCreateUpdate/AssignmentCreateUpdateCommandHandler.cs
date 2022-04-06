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
			List<MasterDataAssignment> spinsertAssignment = null;
            _context.loadStoredProcedureBuilder("SP_InsertUpdate_AssignmentMasterData")
				.AddParam("ID", request.Data.Id.HasValue ? request.Data.Id : 0)
                .AddParam("VendorCode", request.Data.VendorCode)
                .AddParam("ETA", request.Data.ETA)
                .AddParam("ShipID", request.Data.ShipID)
                .AddParam("UpdatedBy", request.Data.UpdatedBy)
                .Exec(r => spinsertAssignment = r.ToList<MasterDataAssignment>());
				
			if (spinsertAssignment.Any())
			{
				foreach (var result in spinsertAssignment)
				{
					response.Success = true;
					response.Message = result.Message;
            
					return response;
				}
			}
			
            response.Success = true;
            response.Message = "Assignment berhasil dibuat atau diupdate";
            
            return response;
        }
    }
}
