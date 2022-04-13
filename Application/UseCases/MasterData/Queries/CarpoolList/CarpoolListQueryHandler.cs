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

namespace SceletonAPI.Application.UseCases.MasterData.Queries.CarpoolList
{
    public class CarpoolListQueryHandler : IRequestHandler<CarpoolListQuery, CarpoolListDto>
    {
        private readonly IVTSDBContext _context;
        private readonly IMapper _mapper;

        public CarpoolListQueryHandler(IVTSDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CarpoolListDto> Handle(CarpoolListQuery request, CancellationToken cancellationToken)
        {
            var response = new CarpoolListDto();

            List<CarpoolListDtoData> data = null;
            CarpoolListDtoMeta meta = null;

            _context.loadStoredProcedureBuilder("SP_List_CarpoolMasterData")
                .AddParam("Page", request.Page != null ? request.Page : 0)
                .AddParam("Limit", request.Limit)
                .Exec(r => data = r.ToList<CarpoolListDtoData>());

            _context.loadStoredProcedureBuilder("SP_List_CarpoolMasterData")
                .AddParam("Page", request.Page != null ? request.Page : 0)
                .AddParam("Limit", request.Limit)
                .Exec(r =>
                {
                    meta = r.First<CarpoolListDtoMeta>();
                });

            if (!data.Any())
            {
                response.Success = true;
                response.Message = "Carpool tidak ditemukan";

                return response;
            }

            response.Data = data;
            response.Meta = meta;
            response.Meta.Page = request.Page > 0 ? request.Page : 1;
            response.Meta.Limit = request.Limit > 0 ? request.Limit : meta.TotalData;
 
            response.Success = true;
            response.Message = "Daftar carpool berhasil ditemukan";

            return response;
        }
    }
}
