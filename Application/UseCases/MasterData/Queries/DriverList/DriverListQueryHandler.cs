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

namespace SceletonAPI.Application.UseCases.MasterData.Queries.DriverList
{
    public class DriverListQueryHandler : IRequestHandler<DriverListQuery, DriverListDto>
    {
        private readonly IVTSDBContext _context;
        private readonly IMapper _mapper;

        public DriverListQueryHandler(IVTSDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DriverListDto> Handle(DriverListQuery request, CancellationToken cancellationToken)
        {
            var response = new DriverListDto();

            List<DriverListDtoData> data = null;
            DriverListDtoMeta meta = null;

            _context.loadStoredProcedureBuilder("SP_List_DriverMasterData")
                .AddParam("Page", request.Page != null ? request.Page : 0)
                .AddParam("Limit", request.Limit)
                .Exec(r => data = r.ToList<DriverListDtoData>());

            _context.loadStoredProcedureBuilder("SP_List_DriverMasterData")
                .AddParam("Page", request.Page != null ? request.Page : 0)
                .AddParam("Limit", request.Limit)
                .Exec(r =>
                {
                    meta = r.First<DriverListDtoMeta>();
                });

            if (!data.Any())
            {
                response.Success = false;
                response.Message = "Driver tidak ditemukan";

                return response;
            }

            response.Data = data;
            response.Meta = meta;
            response.Meta.Page = request.Page > 0 ? request.Page : 1;
            response.Meta.Limit = request.Limit > 0 ? request.Limit : meta.TotalData;
 
            response.Success = true;
            response.Message = "Daftar driver berhasil ditemukan";

            return response;
        }
    }
}
