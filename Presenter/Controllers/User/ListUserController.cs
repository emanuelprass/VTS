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

namespace SceletonAPI.Presenter.Controllers.User
{
    [Route("api/user")]
    [ApiController]
    public class ListUserController : ControllerBase
    {
        private IConfiguration _config;

        public ListUserController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpGet]
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
    }
}
