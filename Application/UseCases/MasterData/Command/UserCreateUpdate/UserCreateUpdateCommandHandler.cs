using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoredProcedureEFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using SceletonAPI.Application.UseCases.MasterData.Command.UserCreateUpdate;
using SceletonAPI.Application.Interfaces;
using SceletonAPI.Domain.Entities;

namespace SFIDWebAPI.Application.UseCases.User.Otoleap.Command.UserCreateUpdate
{
    public class UserCreateUpdateCommandHandler : IRequestHandler<UserCreateUpdateCommand, UserCreateUpdateDto>
    {
        private readonly IVTSDBContext _context;
        private readonly IMapper _mapper;

        public UserCreateUpdateCommandHandler(IVTSDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserCreateUpdateDto> Handle(UserCreateUpdateCommand request, CancellationToken cancellationToken)
        {
            var response = new UserCreateUpdateDto();

            List<MasterDataUser> spinsertUser = null;
            _context.loadStoredProcedureBuilder("SP_InsertUpdate_UserMasterData")
                .AddParam("ID", request.Data.ID)
                .AddParam("FullName", request.Data.FullName)
                .AddParam("Email", request.Data.Email)
                .AddParam("Company", request.Data.Company)
                .AddParam("VendorName", request.Data.VendorName)
                .AddParam("UserRole", request.Data.UserRole)
                .AddParam("Password", request.Data.Password)
                .AddParam("ConfPassword", request.Data.ConfPassword)
                .AddParam("UpdatedBy", request.Data.UpdatedBy)
                .Exec(r => spinsertUser = r.ToList<MasterDataUser>());

			if (spinsertUser.Any())
			{
				foreach (var result in spinsertUser)
				{
					response.Success = true;
					response.Message = result.Message;
            
					return response;
				}
			}
			
            response.Success = true;
            response.Message = "User berhasil dibuat atau diupdate";
            
            return response;
        }
    }
}
