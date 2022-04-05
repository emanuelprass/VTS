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
using SceletonAPI.Application.UseCases.MasterData.Command.DriverCreateUpdate;
using SceletonAPI.Application.Interfaces;
using SceletonAPI.Domain.Entities;

namespace SceletonAPI.Application.UseCases.MasterData.Command.DriverCreateUpdate
{
    public class DriverCreateUpdateCommandHandler : IRequestHandler<DriverCreateUpdateCommand, DriverCreateUpdateDto>
    {
        private readonly IVTSDBContext _context;
        private readonly IMapper _mapper;

        public DriverCreateUpdateCommandHandler(IVTSDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DriverCreateUpdateDto> Handle(DriverCreateUpdateCommand request, CancellationToken cancellationToken)
        {
            var response = new DriverCreateUpdateDto();

            List<MasterDataDriver> spinsertDriver = null;
            _context.loadStoredProcedureBuilder("SP_InsertUpdate_DriverMasterData")
				.AddParam("ID", request.Data.Id.HasValue ? request.Data.Id : 0)
                .AddParam("FullName", request.Data.FullName)
				.AddParam("Phone", request.Data.Phone)
                .AddParam("VendorID", request.Data.VendorId)
                .AddParam("Password", request.Data.Password)
                .AddParam("ConfPassword", request.Data.ConfPassword)
                .AddParam("UpdatedBy", request.Data.UpdatedBy)
                .Exec(r => spinsertDriver = r.ToList<MasterDataDriver>());

			if (spinsertDriver.Any())
			{
				foreach (var result in spinsertDriver)
				{
					response.Success = true;
					response.Message = result.Message;
					
					return response;
				}
			}
			
            response.Success = true;
            response.Message = "Driver berhasil dibuat atau diupdate";
            
            return response;
        }
    }
}
