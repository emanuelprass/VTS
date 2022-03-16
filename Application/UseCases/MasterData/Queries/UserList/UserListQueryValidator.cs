using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Queries.UserList
{
    public class UserListQueryValidator : AbstractValidator<UserListQuery>
    {
        public UserListQueryValidator()
        {
        }
    }
}
