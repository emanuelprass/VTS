using System;
using SceletonAPI.Application.Interfaces.Authorization;

namespace SceletonAPI.Infrastructure.Authorization
{
    public class AuthUser : IAuthUser
    {
        public string name { set; get; }
        public string company { set; get; }
        public string role { set; get; }
        public int expired { set; get; }
        public string token { set; get; }
    }
}
