using AutoMapper;
using MediatR;
using SceletonAPI.Application.Interfaces;
using StoredProcedureEFCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Queries.DeliveryOrderList
{
	public class DeliveryOrderListQueryHandler : IRequestHandler<DeliveryOrderListQuery, DeliveryOrderListDto>
	{
        private readonly IVTSDBContext _context;
        private readonly IMapper _mapper;

        public DeliveryOrderListQueryHandler(IVTSDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DeliveryOrderListDto> Handle(DeliveryOrderListQuery request, CancellationToken cancellationToken)
        {
            var response = new DeliveryOrderListDto();

            List<DeliveryOrderListDtoData> DeliveryOrders = null;
            _context.loadStoredProcedureBuilder("sp_List_DeliveryOrderMasterData")
                .AddParam("Page", request.Page != null ? request.Page : 0)
                .AddParam("Limit", request.Limit)
                .AddParam("Filter", request.Filter)
                .Exec(r => DeliveryOrders = r.ToList<DeliveryOrderListDtoData>());

            if (!DeliveryOrders.Any())
            {
                response.Success = true;
                response.Message = "Delivery Order tidak ditemukan";

                return response;
            }

            response.Data = DeliveryOrders;

            response.Success = true;
            response.Message = "Daftar Delivery Order berhasil ditemukan";

            return response;
        }
    }
}
