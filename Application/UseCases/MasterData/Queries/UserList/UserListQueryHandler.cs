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

            List<UserListDtoData> data = new();
            UserListDtoMeta meta = null;
            
            _context.loadStoredProcedureBuilder("SP_List_UserMasterData")
                .AddParam("Page", request.Page != null ? request.Page : 0)
                .AddParam("Limit", request.Limit)
                .AddParam("Role", request.Role)
                .Exec(r => data = r.ToList<UserListDtoData>());

            _context.loadStoredProcedureBuilder("SP_List_UserMasterData")
                .AddParam("Page", request.Page != null ? request.Page : 0)
                .AddParam("Limit", request.Limit)
                .AddParam("Role", request.Role)
                .Exec(r =>
                {
                    meta = r.First<UserListDtoMeta>();
                });

            if (!data.Any())
            {
                response.Success = true;
                response.Message = "User tidak ditemukan";
            }

            response.Data = data;
            response.Meta = meta;
            response.Meta.Page = request.Page > 0 ? request.Page : 1;
            response.Meta.Limit = request.Limit > 0 ? request.Limit : meta.TotalData;

            response.Success = true;
            response.Message = "Daftar user berhasil ditemukan";
            return response;
        }
    }
}
