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

namespace SceletonAPI.Application.UseCases.MasterData.Command.VendorCreateUpdate
{
	public class VendorCreateUpdateCommandHandler : IRequestHandler<VendorCreateUpdateCommand, VendorCreateUpdateDto>
	{
        private readonly IVTSDBContext _context;
        private readonly IMapper _mapper;

        public VendorCreateUpdateCommandHandler(IVTSDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

		public async Task<VendorCreateUpdateDto> Handle(VendorCreateUpdateCommand request, CancellationToken cancellationToken)
		{
			// var testing
			var response = new VendorCreateUpdateDto();
			foreach(var i in request.data)
            {
				Console.WriteLine("test"+i.lfa1_lifnr);

				List<MasterDataVendor> spinsertUser = null;
				_context.loadStoredProcedureBuilder("sp_InsertUpdate_VendorMasterData")
				.AddParam("Code", i.lfa1_lifnr)
				.AddParam("Name", i.lfa1_name1)
				.AddParam("Name2", i.lfa1_name2)
				.AddParam("Grade", i.lfa1_name3)
				.AddParam("Country", i.lfa1_land1)
				.AddParam("City", i.lfa1_ort01)
				.AddParam("PostalCode", i.lfa1_pstlz)
				.AddParam("Region", i.lfa1_regio)
				.AddParam("Street", i.lfa1_stras)
				.AddParam("DeletionFlag", i.lfa1_loevm)
				.AddParam("PostingBlock", i.lfa1_sperr)
				.AddParam("PurchaseBlock", i.lfa1_sperm)
				.AddParam("CreatedOn", i.lfa1_erdat)
				.AddParam("Telephone", i.adr2_tel_number)
				.AddParam("Email", i.adr6_smtp_addr)
				.AddParam("CreatedBy", i.created_by)
				.AddParam("UpdatedBy", i.updated_by)
				.Exec(r => spinsertUser = r.ToList<MasterDataVendor>());
            }

			response.Success = true;
			response.Message = "Vendor berhasil dibuat atau diupdate";

			return response;
		}
	}
}
