using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Microsoft.EntityFrameworkCore;
using SceletonAPI.Application.Interfaces.Authorization;
using SceletonAPI.Application.Interfaces;
using System.Threading;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace SceletonAPI.Infrastructure.Authorization
{
    public class AuthmeMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthmeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task InvokeAsync(HttpContext context, IDBContext dbContext, IAuthUser authUser)
        {
            var authFilterCtx = context.Request;
            var request = authFilterCtx.HttpContext.Request;

            var TypeOfReqest = request.Path.ToString();
            if (request.Path.ToString().StartsWith("/auth", StringComparison.CurrentCultureIgnoreCase)) 
            {
                return _next.Invoke(context);
            }
            

            string authHeader = "";
            if (context.Request.Headers.TryGetValue("Authorization", out StringValues authToken))
            {
                authHeader = authToken.SingleOrDefault();
            }
            else
            {
               
                throw new UnauthorizedAccessException();
                
            }

            if (String.IsNullOrEmpty(authHeader)) throw new UnauthorizedAccessException();

            var token = authHeader.Replace("Bearer", "").Trim();

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiY29tcGFueSI6Ik1NS1NJIiwicm9sZSI6IkFkbWluIiwiZXhwaXJlZCI6MTUxNjIzOTAyMiwiaWF0IjoxNTE2MjM5MDIyfQ.gwHLxeSELj9SlH50-SD-JeiHkXkI0abmol5LFnBrze8");
            var tokenS = jsonToken as JwtSecurityToken;

            //byte[] symmetricKey = Convert.FromBase64String("db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==");

            //SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(symmetricKey);

            //TokenValidationParameters tokenValidationParameters = new TokenValidationParameters()
            //{
            //    ValidateIssuerSigningKey = true,
            //    IssuerSigningKey = symmetricSecurityKey
            //};

            //handler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
            //var tokenExpiresAt = validatedToken.ValidTo;

            authUser.name = tokenS.Claims.First(claim => claim.Type == "name").Value;
            authUser.company = tokenS.Claims.First(claim => claim.Type == "company").Value;
            authUser.role = tokenS.Claims.First(claim => claim.Type == "role").Value;
            authUser.expired = Convert.ToInt32(tokenS.Claims.First(claim => claim.Type == "expired").Value);
            authUser.token = token;

            return _next.Invoke(context);
        }
    }
}
