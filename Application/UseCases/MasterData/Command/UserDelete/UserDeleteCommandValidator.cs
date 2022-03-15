using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Command.UserDelete
{
    public class UserDeleteCommandValidator : AbstractValidator<UserDeleteCommand>
    {
        public UserDeleteCommandValidator()
        {
        }
    }
}
