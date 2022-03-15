using MediatR;
using SceletonAPI.Application.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Command.UserCreateUpdate
{
    public class UserCreateUpdateCommand : BaseQueryCommand, IRequest<UserCreateUpdateDto>
    {
        public UserCreateUpdateCommandData Data { set; get; }
    }
    public class UserCreateUpdateCommandData
    {
        public int ID { set; get; }
        public string FullName { set; get; }
        public string Email { set; get; }
        public string Company { set; get; }
        public string VendorName { set; get; }
        public string UserRole { set; get; }
        public string Password { set; get; }
        public string ConfPassword { set; get; }
        public string UpdatedBy { set; get; }

    }
}
