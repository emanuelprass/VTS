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
using System.Data.Common;

namespace SceletonAPI.Application.UseCases.MasterData.Queries.PricingList
{
    public class PricingListQueryHandler : IRequestHandler<PricingListQuery, PricingListDto>
    {
        private readonly IVTSDBContext _context;
        private readonly IMapper _mapper;

        public PricingListQueryHandler(IVTSDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PricingListDto> Handle(PricingListQuery request, CancellationToken cancellationToken)
        {
            var response = new PricingListDto();

            List<PricingListDtoData> data = null;
            PricingListDtoMeta meta = null;

            _context.loadStoredProcedureBuilder("SP_List_PricingMasterData")
                .AddParam("Page", request.Page != null ? request.Page : 0)
                .AddParam("Limit", request.Limit)
                .Exec(r => data = r.ToList<PricingListDtoData>());

            _context.loadStoredProcedureBuilder("SP_List_PricingMasterData")
                .AddParam("Page", request.Page != null ? request.Page : 0)
                .AddParam("Limit", request.Limit)
                .Exec(r =>
                {
                    meta = r.First<PricingListDtoMeta>();
                });

            if (!data.Any())
            {
                response.Success = false;
                response.Message = "Pricing tidak ditemukan";

                return response;
            }

            response.Data = data;
            response.Meta = meta;
            response.Meta.Page = request.Page > 0 ? request.Page : 1;
            response.Meta.Limit = request.Limit > 0 ? request.Limit : meta.TotalData;
 
            response.Success = true;
            response.Message = "Daftar pricing berhasil ditemukan";

            return response;
        }
    }
}
