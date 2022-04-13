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

namespace SceletonAPI.Application.UseCases.MasterData.Queries.AssignmentList
{
    public class AssignmentListQueryHandler : IRequestHandler<AssignmentListQuery, AssignmentListDto>
    {
        private readonly IVTSDBContext _context;
        private readonly IMapper _mapper;

        public AssignmentListQueryHandler(IVTSDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AssignmentListDto> Handle(AssignmentListQuery request, CancellationToken cancellationToken)
        {
            var response = new AssignmentListDto();

			AssignmentListDtoMeta meta = null;
            List<AssignmentListDtoData> data = null;
			List<PickUp> pickUp = null;

            _context.loadStoredProcedureBuilder("SP_List_AssignmentMasterData")
                .AddParam("Page", request.Page != null ? request.Page : 0)
                .AddParam("Limit", request.Limit)
                .Exec(r => data = r.ToList<AssignmentListDtoData>());
			
			if (!data.Any())
            {
                response.Success = true;
                response.Message = "Assignment tidak ditemukan";

                return response;
            }
			
			foreach (var dat in data)
			{
				_context.loadStoredProcedureBuilder("SP_List_AssignmentMasterData")
					.AddParam("Page", request.Page != null ? request.Page : 0)
					.AddParam("Limit", request.Limit)
					.AddParam("ID", dat.ID)
					.Exec(r => pickUp = r.ToList<PickUp>());
			}
            _context.loadStoredProcedureBuilder("SP_List_AssignmentMasterData")
                .AddParam("Page", request.Page != null ? request.Page : 0)
                .AddParam("Limit", request.Limit)
                .Exec(r => meta = r.First<AssignmentListDtoMeta>());
			
            response.Meta = meta;
			response.Meta.Page = request.Page > 0 ? request.Page : 1;
            response.Meta.Limit = request.Limit > 0 ? request.Limit : meta.TotalData;
			
			foreach (var dat in data)
			{
				dat.PickUp = pickUp;
			}
			
			response.Data = data;
			
            response.Success = true;
            response.Message = "Daftar assignment berhasil ditemukan";

            return response;
        }
    }
}
