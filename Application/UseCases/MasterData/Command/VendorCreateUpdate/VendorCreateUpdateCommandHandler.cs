using AutoMapper;
using MediatR;
using SceletonAPI.Application.Interfaces;
using SceletonAPI.Domain.Entities;
using StoredProcedureEFCore;
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
			var response = new VendorCreateUpdateDto();

			List<MasterDataVendor> spinsertUser = null;
			_context.loadStoredProcedureBuilder("sp_InsertUpdate_VendorMasterData")
				.AddParam("ID", request.ID)
				.AddParam("Code", request.Code)
				.AddParam("Name", request.Name)
				.AddParam("Name2", request.Name2)
				.AddParam("Grade", request.Grade)
				.AddParam("Country", request.Country)
				.AddParam("City", request.City)
				.AddParam("PostalCode", request.PostalCode)
				.AddParam("Region", request.Region)
				.AddParam("Street", request.Street)
				.AddParam("DeletionFlag", request.DeletionFlag)
				.AddParam("PostingBlock", request.PostingBlock)
				.AddParam("PurchaseBlock", request.PurchBlock)
				.AddParam("CreatedOn", request.CreatedOn)
				.AddParam("Telephone", request.Telephone)
				.AddParam("Email", request.Email)
				.AddParam("CreatedBy", request.CreatedBy)
				.AddParam("UpdatedBy", request.UpdatedBy)
				.Exec(r => spinsertUser = r.ToList<MasterDataVendor>());

			response.Success = true;
			response.Message = "Vendor berhasil dibuat atau diupdate";

			return response;
		}
	}
}
