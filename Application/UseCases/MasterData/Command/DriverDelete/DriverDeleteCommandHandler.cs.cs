using AutoMapper;
using MediatR;
using SceletonAPI.Application.Interfaces;
using SceletonAPI.Domain.Entities;
using StoredProcedureEFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Command.DriverDelete
{
    public class DriverDeleteCommandHandler : IRequestHandler<DriverDeleteCommand, DriverDeleteDto>
    {
        private readonly IVTSDBContext _context;
        private readonly IMapper _mapper;

        public DriverDeleteCommandHandler(IVTSDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DriverDeleteDto> Handle(DriverDeleteCommand request, CancellationToken cancellationToken)
        {
            var response = new DriverDeleteDto();

            List<MasterDataDriver> spinsertDriver = null;
            _context.loadStoredProcedureBuilder("SP_Delete_DriverMasterData")
                .AddParam("ID", request.Data.Id)
                .AddParam("UpdatedBy", request.Data.UpdatedBy)
                .Exec(r => spinsertDriver = r.ToList<MasterDataDriver>());

            response.Success = true;
            response.Message = "Driver berhasil dihapus";

            return response;
        }
    }
}
