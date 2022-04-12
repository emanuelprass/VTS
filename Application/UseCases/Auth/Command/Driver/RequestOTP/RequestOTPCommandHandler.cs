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
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Http;

namespace SceletonAPI.Application.UseCases.Auth.Command.Driver.RequestOTP
{
    public class RequestOTPCommandHandler : IRequestHandler<RequestOTPCommand, RequestOTPDto>
    {
        private readonly IVTSDBContext _context;
        private readonly IMapper _mapper;

        public RequestOTPCommandHandler(IVTSDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RequestOTPDto> Handle(RequestOTPCommand request, CancellationToken cancellationToken)
        {
            var response = new RequestOTPDto();

            List<RequestOTPDtoData> data = null;
            _context.loadStoredProcedureBuilder("SP_Driver_RequestOTP")
                .AddParam("Phone", request.Data.Phone)
                .Exec(r => data = r.ToList<RequestOTPDtoData>());

			foreach (var result in data)
			{
				if (result.OTP == null)
				{
					response.Success = true;
					response.Message = result.Phone;
					
					return response;
				}
			response.Data = result;
			}
			
            string endpoint = "https://apps.mitsubishi-motors.co.id/DNETSMS/api/MessageService";

            string input = @"{
							""ClientID"": ""fd9d43e1-2f4f-4f80-84cd-82c26f9c7892"",
							""UserName"": ""SAPProd"",
							""Password"": ""P@s5w0rd.PR0d_SAP22"",
							""TypeMessage"": ""1"",
							""BodyMessage"": ""text:=:{MMKSI Vehicle Tracking System||text:=:" + response.Data.OTP + @"||text:=:{Admin VTS"",
							""DestinationNo"": " + response.Data.Phone + @"
							}";

            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;

            string message = await Task.Run(() => client.UploadString(endpoint, input));

			response.Success = true;
            response.Message = message;
			
			return response;
        }
    }
}