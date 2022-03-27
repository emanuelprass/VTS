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

namespace SceletonAPI.Application.UseCases.MasterData.Command.DestinationCreateUpdate
{
	public class DestinationCreateUpdateCommandHandler : IRequestHandler<DestinationCreateUpdateCommand, DestinationCreateUpdateDto>
	{
        private readonly IVTSDBContext _context;
        private readonly IMapper _mapper;

        public DestinationCreateUpdateCommandHandler(IVTSDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

		public async Task<DestinationCreateUpdateDto> Handle(DestinationCreateUpdateCommand request, CancellationToken cancellationToken)
		{
			var response = new DestinationCreateUpdateDto();
			foreach(var i in request.data)
            {
				List<MasterDataDestination> spinsertUser = null;
				_context.loadStoredProcedureBuilder("sp_InsertUpdate_DestinationMasterData")
				.AddParam("DealerCode", i.dlrdc)
				.AddParam("DealerName", i.name2)
				.AddParam("SoldToParty", i.kunag)
				.AddParam("TempDestinationCode", i.destcodex)
				.AddParam("DestinationCode", i.destcode)
				.AddParam("DestinationName", i.name1)
				.AddParam("SearchTerm", i.sort1)
				.AddParam("StreetName", i.street)
				.AddParam("City", i.city1)
				.AddParam("Region", i.region)
				.AddParam("PostalCode", i.post_code1)
				.AddParam("CustomerGroup", i.kvgr1)
				.AddParam("DelvLeadTime", i.dlvlt)
				.AddParam("CreatedBy", i.created_by)
				.AddParam("UpdatedBy", i.updated_by)
				.Exec(r => spinsertUser = r.ToList<MasterDataDestination>());
            }

			response.Success = true;
			response.Message = "Destination berhasil dibuat atau diupdate";

			return response;
		}
	}
}
