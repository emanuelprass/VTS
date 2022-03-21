using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Command.DriverDelete
{
    public class DriverDeleteCommandValidator : AbstractValidator<DriverDeleteCommand>
    {
        public DriverDeleteCommandValidator()
        {
            RuleFor(driver => driver.Data.Id).NotEmpty();
        }
    }
}
