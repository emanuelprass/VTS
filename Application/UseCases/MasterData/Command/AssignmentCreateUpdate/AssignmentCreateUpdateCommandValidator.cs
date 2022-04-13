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
			
			When(assignment => assignment.Data.ShipData != null, () => {
				RuleFor(assignment => assignment.Data.ShipData.ShipName).NotEmpty();
				RuleFor(assignment => assignment.Data.ShipData.DeparturePort).NotEmpty();
				RuleFor(assignment => assignment.Data.ShipData.ArrivalPort).NotEmpty();
				RuleFor(assignment => assignment.Data.ShipData.DepartureTime).NotEmpty();
				RuleFor(assignment => assignment.Data.ShipData.ArrivalTime).NotEmpty();
			});
			
			// When(assignment => assignment.Data.Batch != null, () => {
				// RuleFor(assignment => assignment.Data.Batch.DeliveryMode).NotEmpty();
				// RuleFor(assignment => assignment.Data.Batch.PickUpTime).NotEmpty();
				// RuleFor(assignment => assignment.Data.Batch.Timezone).NotEmpty();
			// });
        }
    }
}