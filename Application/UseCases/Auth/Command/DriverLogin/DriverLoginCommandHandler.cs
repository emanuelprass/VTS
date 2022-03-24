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

namespace SceletonAPI.Application.UseCases.Auth.Command.DriverLogin
{
    public class DriverLoginCommandHandler : IRequestHandler<DriverLoginCommand, DriverLoginDto>
    {
        private readonly IVTSDBContext _context;
        private readonly IMapper _mapper;

        public DriverLoginCommandHandler(IVTSDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private IConfiguration _config;

        public async Task<DriverLoginDto> Handle(DriverLoginCommand request, CancellationToken cancellationToken)
        {

            var response = new DriverLoginDto();

            Task<DriverLoginDtoData> driver = null;
            _context.loadStoredProcedureBuilder("SP_Select_DriverMasterData")
                .AddParam("Phone", request.Data.Phone)
                .AddParam("Password", request.Data.Password)
                .Exec(r =>
                {
                    driver = MapDriver(r);
                });

            if (driver.Result == null)
            {
                response.Success = false;
                response.Message = "Driver tidak ditemukan";

                return response;
            }

            var tokenString = GenerateJSONWebToken(driver.Result);
            response.TokenId = tokenString;
            response.TokenType = "Bearer";

            response.Data = driver.Result;
            response.Success = true;
            response.Message = "Login berhasil";

            return response;
        }

        public static async Task<DriverLoginDtoData> MapDriver(DbDataReader dataReader)
        {
            if (await dataReader.ReadAsync() && dataReader.HasRows)
            {
                DriverLoginDtoData driver = new();
                driver.Id = dataReader.GetInt32(dataReader.GetOrdinal("ID"));
                driver.Name = dataReader.GetString(dataReader.GetOrdinal("FullName"));
                driver.VendorName = dataReader.GetString(dataReader.GetOrdinal("VendorName"));
                return driver;
            }
            return null;
        }


        private string GenerateJSONWebToken(DriverLoginDtoData driverInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TemporaryHardCodedSecretKey"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, driverInfo.Id.ToString()),
                        new Claim("name", driverInfo.Name),
                        new Claim("vendor", driverInfo.VendorName),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(24),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}