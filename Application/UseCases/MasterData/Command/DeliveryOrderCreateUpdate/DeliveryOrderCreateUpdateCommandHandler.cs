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

namespace SceletonAPI.Application.UseCases.MasterData.Command.DeliveryOrderCreateUpdate
{
	public class DeliveryOrderCreateUpdateCommandHandler : IRequestHandler<DeliveryOrderCreateUpdateCommand, DeliveryOrderCreateUpdateDto>
	{
        private readonly IVTSDBContext _context;
        private readonly IMapper _mapper;

        public DeliveryOrderCreateUpdateCommandHandler(IVTSDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

		public async Task<DeliveryOrderCreateUpdateDto> Handle(DeliveryOrderCreateUpdateCommand request, CancellationToken cancellationToken)
		{
			var response = new DeliveryOrderCreateUpdateDto();
			foreach(var i in request.data)
            {
				List<MasterDataVendor> spinsertUser = null;
				_context.loadStoredProcedureBuilder("sp_InsertUpdate_DeliveryOrder")
				.AddParam("DO_Number", i.likp_vbeln)
				.AddParam("Dealer_Code", i.likp_kunag)
				.AddParam("Destination_Code", i.likp_kunnr)
				.AddParam("Material_Number", i.lips_matnr)
				.AddParam("Model_Name", i.zfudt0034_model)
				.AddParam("Desc", i.lips_arktx)
				.AddParam("Manufacture_No", i.equz_mapar)
				.AddParam("SO_No", i.lips_vgbel)
				.AddParam("RequstDelvDate", i.vbak_vdatu)
				.AddParam("Chasis_No", i.lips_ean11)
				.AddParam("Storage_Code", i.lips_lgort)
				.Exec(r => spinsertUser = r.ToList<MasterDataVendor>());
            }

			response.Success = true;
			response.Message = "Delivery Order berhasil dibuat atau diupdate";

			return response;
		}
	}
}
