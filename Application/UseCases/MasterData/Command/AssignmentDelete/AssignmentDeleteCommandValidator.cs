using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Command.AssignmentDelete
{
    public class AssignmentDeleteCommandValidator : AbstractValidator<AssignmentDeleteCommand>
    {
        public AssignmentDeleteCommandValidator()
        {
            RuleFor(assignment => assignment.Data.Id).NotEmpty();
        }
    }
}
