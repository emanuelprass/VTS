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

namespace SceletonAPI.Application.UseCases.MasterData.Queries.UserList
{
    public class UserListQueryHandler : IRequestHandler<UserListQuery, UserListDto>
    {
        private readonly IVTSDBContext _context;
        private readonly IMapper _mapper;

        public UserListQueryHandler(IVTSDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserListDto> Handle(UserListQuery request, CancellationToken cancellationToken)
        {
            var response = new UserListDto();

            List<UserListDtoData> users = null;
            _context.loadStoredProcedureBuilder("SP_List_UserMasterData")
                .AddParam("Page", request.Page != null ? request.Page : 0)
                .AddParam("Limit", request.Limit)
                .Exec(r => users = r.ToList<UserListDtoData>());

            if (!users.Any())
            {
                response.Success = false;
                response.Message = "User tidak ditemukan";

                return response;
            }

            response.Data = users;
 
            response.Success = true;
            response.Message = "Daftar user berhasil ditemukan";

            return response;
        }
    }
}
