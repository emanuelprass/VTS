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
using SceletonAPI.Application.Models.Auth;
using Newtonsoft.Json;
using System.IO; 

namespace SceletonAPI.Application.UseCases.Auth.Command.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginDto>
    {
        private readonly IVTSDBContext _context;
        private readonly IMapper _mapper;

        public LoginCommandHandler(IVTSDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private IConfiguration _config;

        public async Task<LoginDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {

            var response = new LoginDto();

            if (request.Data.Email == null || request.Data.Password == null)
            {
                response.Success = false;
                response.Message = "Silakan masukan email dan password";

                return response;
            }
            Console.WriteLine("d");
            Task<LoginDtoData> user = null;
            _context.loadStoredProcedureBuilder("SP_Select_UserMasterData")
                .AddParam("Email", request.Data.Email)
                .AddParam("Password", request.Data.Password)
                .Exec(r =>
                {
                    user = MapContact(r);
                });

            if (user.Result == null)
            {
                response.Success = false;
                response.Message = "User tidak ditemukan";

                return response;
            }

            var tokenString = GenerateJSONWebToken(user.Result);
            response.TokenId = tokenString;
            response.TokenType = "Bearer";

            response.Data = user.Result;
            response.Success = true;
            response.Message = "Login berhasil";

            return response;
        }

        public static async Task<LoginDtoData> MapContact(DbDataReader dataReader)
        {
            if (await dataReader.ReadAsync() && dataReader.HasRows)
            {
                LoginDtoData user = new();
                user.Id = dataReader.GetInt32(dataReader.GetOrdinal("ID"));
                user.Name = dataReader.GetString(dataReader.GetOrdinal("FullName"));
                user.Company = dataReader.GetString(dataReader.GetOrdinal("Company"));
                user.Role = dataReader.GetString(dataReader.GetOrdinal("Role"));
                return user;
            }
            return null;
        }


        private string GenerateJSONWebToken(LoginDtoData userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TemporaryHardCodedSecretKey"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, userInfo.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, userInfo.Name),
                        new Claim("company", userInfo.Company),
                        new Claim("role", userInfo.Role),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}