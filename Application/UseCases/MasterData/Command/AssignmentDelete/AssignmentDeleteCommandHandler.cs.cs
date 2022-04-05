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

namespace SceletonAPI.Application.UseCases.MasterData.Command.AssignmentDelete
{
    public class AssignmentDeleteCommandHandler : IRequestHandler<AssignmentDeleteCommand, AssignmentDeleteDto>
    {
        private readonly IVTSDBContext _context;
        private readonly IMapper _mapper;

        public AssignmentDeleteCommandHandler(IVTSDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AssignmentDeleteDto> Handle(AssignmentDeleteCommand request, CancellationToken cancellationToken)
        {
            var response = new AssignmentDeleteDto();

            List<MasterDataAssignment> spinsertAssignment = null;
            _context.loadStoredProcedureBuilder("SP_Delete_AssignmentMasterData")
                .AddParam("ID", request.Data.Id)
                .AddParam("UpdatedBy", request.Data.UpdatedBy)
                .Exec(r => spinsertAssignment = r.ToList<MasterDataAssignment>());

            response.Success = true;
            response.Message = "Assignment berhasil dihapus";

            return response;
        }
    }
}
