using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Command.AssignmentCreateUpdate
{
    
    public class AssignmentCreateUpdateCommandValidator : AbstractValidator<AssignmentCreateUpdateCommand>
    {
        public AssignmentCreateUpdateCommandValidator()
        {
			When(assignment => assignment.Data.Id > 0, () => {
				RuleFor(assignment => assignment.Data.VendorCode).NotEmpty();
				RuleFor(assignment => assignment.Data.ETA).NotEmpty();
			});
        }
    }
}