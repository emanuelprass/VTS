using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SceletonAPI.Application.Models.Auth;
using Newtonsoft.Json;

namespace SceletonAPI.Presenter.Controllers.User
{
    [Route("api/v1/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        class UserData
        {
            public string email;
            public string role;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(UserModel model)
        {
            StatusCodeModel resp = new();

            if (model.Email == null || model.Password == null)
            {
                resp.StatusCode = 400;
                resp.Message = "Please provide email and password";
                return BadRequest(resp);
            }

            try
            {
                string connString = _config["ConnectionStrings:MasterData"];

                using (SqlConnection sqlConn = new(connString))
                {
                    SqlCommand sqlCmd = new("dbo.sp_SelectUser", sqlConn);

                    sqlCmd.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = model.Email;
                    sqlCmd.Parameters.AddWithValue("@password", SqlDbType.NVarChar).Value = model.Password;

                    sqlConn.Open();
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader dr = sqlCmd.ExecuteReader();

                    //check if there are records
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            //display retrieved record

                            UserData userData = new();
                            userData.email = dr.GetString(2);
                            userData.role = dr.GetInt16(5).ToString();
                            var user = JsonConvert.SerializeObject(userData);

                            var tokenString = GenerateJSONWebToken(user);
                            TokenModel token = new();
                            token.TokenId = tokenString;
                            token.TokenType = "Bearer";
                            return Ok(token);
                        }
                    }

                    //close data reader
                    dr.Close();
                    sqlConn.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return StatusCode(500);
            }

            resp.StatusCode = 400;
            resp.Message = "User not found";
            return BadRequest(resp);
        }

        private string GenerateJSONWebToken(String userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Email, userInfo),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
