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

namespace SceletonAPI.Application.UseCases.MasterData.Command.UserDelete
{
    public class UserDeleteCommandHandler : IRequestHandler<UserDeleteCommand, UserDeleteDto>
    {
        private readonly IVTSDBContext _context;
        private readonly IMapper _mapper;

        public UserDeleteCommandHandler(IVTSDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDeleteDto> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            var response = new UserDeleteDto();

            List<MasterDataUser> spinsertUser = null;
            _context.loadStoredProcedureBuilder("SP_Delete_UserMasterData")
                .AddParam("ID", request.Data.ID)
                .AddParam("UpdatedBy", request.Data.UpdatedBy)
                .Exec(r => spinsertUser = r.ToList<MasterDataUser>());

            response.Success = true;
            response.Message = "User berhasil dihapus";

            return response;
        }
    }
}
