using AutoMapper;
using MediatR;
using SceletonAPI.Application.Interfaces;
using StoredProcedureEFCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Queries.DestinationList
{
	public class DestinationListQueryHandler : IRequestHandler<DestinationListQuery, DestinationListDto>
	{
        private readonly IVTSDBContext _context;
        private readonly IMapper _mapper;

        public DestinationListQueryHandler(IVTSDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DestinationListDto> Handle(DestinationListQuery request, CancellationToken cancellationToken)
        {
            var response = new DestinationListDto();

            List<DestinationListDtoData> Destinations = null;
            _context.loadStoredProcedureBuilder("sp_List_DestinationMasterData")
                .AddParam("Page", request.Page != null ? request.Page : 0)
                .AddParam("Limit", request.Limit)
                .Exec(r => Destinations = r.ToList<DestinationListDtoData>());

            if (!Destinations.Any())
            {
                response.Success = false;
                response.Message = "Destination tidak ditemukan";

                return response;
            }

            response.Data = Destinations;

            response.Success = true;
            response.Message = "Daftar Destination berhasil ditemukan";

            return response;
        }
    }
}
