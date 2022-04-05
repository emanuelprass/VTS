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

			PricingListDtoMeta meta = null;
			List<ModelKendaraan> model = null;
            List<PricingListDtoData> data = null;
			// List<Destination> destinations = null;
			// List<Vendor> vendors = null;
			List<Pricing> pricings = null;

            _context.loadStoredProcedureBuilder("SP_List_PricingMasterData")
                .AddParam("Page", request.Page != null ? request.Page : 0)
                .AddParam("Limit", request.Limit)
                .Exec(r => data = r.ToList<PricingListDtoData>());
			
			if (!data.Any())
            {
                response.Success = true;
                response.Message = "Pricing tidak ditemukan";

                return response;
            }
				
			_context.loadStoredProcedureBuilder("SP_List_PricingMasterData")
                .AddParam("Distinct", "ModelName")
                .Exec(r => model = r.ToList<ModelKendaraan>());	

            _context.loadStoredProcedureBuilder("SP_List_PricingMasterData")
                .AddParam("Page", request.Page != null ? request.Page : 0)
                .AddParam("Limit", request.Limit)
                .Exec(r => meta = r.First<PricingListDtoMeta>());
			
            response.Meta = meta;
			response.Meta.Page = request.Page > 0 ? request.Page : 1;
            response.Meta.Limit = request.Limit > 0 ? request.Limit : meta.TotalData;
            response.Model = model;
			response.Data = data;
			
			foreach(var value in response.Data)
            {
				_context.loadStoredProcedureBuilder("SP_List_PricingMasterData")
				.AddParam("Region", value.Region)
				.AddParam("DestinationCode", value.DestinationCode)
				.AddParam("VendorCode", value.VendorCode)
				.Exec(r => pricings = r.ToList<Pricing>());
				value.Pricing = pricings;
			}
				// Uncomment in case data hierarchy wanted to be same as excel VendorPrice
                // _context.loadStoredProcedureBuilder("SP_List_PricingMasterData")
                // .AddParam("Region", value.Region)
                // .Exec(r => destinations = r.ToList<Destination>());
                // value.Destination = destinations;
				
				// foreach(var destination in value.Destination)
				// {
					// _context.loadStoredProcedureBuilder("SP_List_PricingMasterData")
					// .AddParam("Region", value.Region)
					// .AddParam("DestinationCode", destination.DestinationCode)
					// .Exec(r => vendors = r.ToList<Vendor>());
					// destination.Vendor = vendors;
					
					// foreach(var vendor in destination.Vendor)
					// {
						// _context.loadStoredProcedureBuilder("SP_List_PricingMasterData")
						// .AddParam("Region", value.Region)
						// .AddParam("DestinationCode", destination.DestinationCode)
						// .AddParam("VendorCode", vendor.VendorCode)
						// .Exec(r => pricings = r.ToList<Pricing>());
						// vendor.Pricing = pricings;
					// }
				// }
            // }
 
            response.Success = true;
            response.Message = "Daftar pricing berhasil ditemukan";

            return response;
        }
    }
}
