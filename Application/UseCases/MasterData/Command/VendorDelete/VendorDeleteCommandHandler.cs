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

namespace SceletonAPI.Application.UseCases.MasterData.Command.VendorDelete
{
	public class VendorDeleteCommandHandler : IRequestHandler<VendorDeleteCommand, VendorDeleteDto>
	{
        private readonly IVTSDBContext _context;
        private readonly IMapper _mapper;

        public VendorDeleteCommandHandler(IVTSDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VendorDeleteDto> Handle(VendorDeleteCommand request, CancellationToken cancellationToken)
        {
            var response = new VendorDeleteDto();

            List<MasterDataVendor> deleteVendor = null;
            _context.loadStoredProcedureBuilder("sp_Delete_VendorMasterData")
                .AddParam("ID", request.Data.ID)
                .AddParam("UpdatedBy", request.Data.UpdatedBy)
                .Exec(r => deleteVendor = r.ToList<MasterDataVendor>());

            response.Success = true;
            response.Message = "Vendor berhasil dihapus";

            return response;
        }
    }
}
