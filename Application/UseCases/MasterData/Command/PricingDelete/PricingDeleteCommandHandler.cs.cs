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

namespace SceletonAPI.Application.UseCases.MasterData.Command.PricingDelete
{
    public class PricingDeleteCommandHandler : IRequestHandler<PricingDeleteCommand, PricingDeleteDto>
    {
        private readonly IVTSDBContext _context;
        private readonly IMapper _mapper;

        public PricingDeleteCommandHandler(IVTSDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PricingDeleteDto> Handle(PricingDeleteCommand request, CancellationToken cancellationToken)
        {
            var response = new PricingDeleteDto();

            List<MasterDataPricing> spinsertPricing = null;
            _context.loadStoredProcedureBuilder("SP_Delete_PricingMasterData")
                .AddParam("ID", request.Data.Id)
                .AddParam("UpdatedBy", request.Data.UpdatedBy)
                .Exec(r => spinsertPricing = r.ToList<MasterDataPricing>());

            response.Success = true;
            response.Message = "Pricing berhasil dihapus";

            return response;
        }
    }
}
