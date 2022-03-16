using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Command.UserList
{
    public class UserListCommandValidator : AbstractValidator<UserListCommand>
    {
        public UserListCommandValidator()
        {
        }
    }
}
