using AutoMapper;
using MediatR;
using SceletonAPI.Application.Interfaces;
using SceletonAPI.Domain.Entities;
using StoredProcedureEFCore;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Data.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.IO; 

namespace SceletonAPI.Application.UseCases.Auth.Command.Driver.Activate
{
    public class ActivateCommandHandler : IRequestHandler<ActivateCommand, ActivateDto>
    {
        private readonly IVTSDBContext _context;
        private readonly IMapper _mapper;

        public ActivateCommandHandler(IVTSDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private IConfiguration _config;

        public async Task<ActivateDto> Handle(ActivateCommand request, CancellationToken cancellationToken)
        {

            var response = new ActivateDto();

            List<ActivateDtoData> data = null;
            _context.loadStoredProcedureBuilder("SP_Driver_Activation")
                .AddParam("Phone", request.Data.Phone)
                .AddParam("OTP", request.Data.OTP)
                .Exec(r => data = r.ToList<ActivateDtoData>());

            foreach (var result in data)
			{
				if (result.Message != null)
				{
					response.Success = true;
					response.Message = result.Message;
					
					return response;
				}
			}
			
			response.Success = true;
            response.Message = "Akun anda berhasil diaktivasi. Silakan login";
			
			return response;
        }
    }
}