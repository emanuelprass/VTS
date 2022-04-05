using AutoMapper;
using MediatR;
using SceletonAPI.Application.Interfaces;
using StoredProcedureEFCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Queries.VendorList
{
	public class VendorListQueryHandler : IRequestHandler<VendorListQuery, VendorListDto>
	{
        private readonly IVTSDBContext _context;
        private readonly IMapper _mapper;

        public VendorListQueryHandler(IVTSDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VendorListDto> Handle(VendorListQuery request, CancellationToken cancellationToken)
        {
            var response = new VendorListDto();

            List<VendorListDtoData> vendors = null;
            _context.loadStoredProcedureBuilder("sp_List_VendorMasterData")
                .AddParam("Page", request.Page != null ? request.Page : 0)
                .AddParam("Limit", request.Limit)
                .Exec(r => vendors = r.ToList<VendorListDtoData>());

            if (!vendors.Any())
            {
                response.Success = true;
                response.Message = "Vendor tidak ditemukan";

                return response;
            }

            response.Data = vendors;

            response.Success = true;
            response.Message = "Daftar vendor berhasil ditemukan";

            return response;
        }
    }
}
