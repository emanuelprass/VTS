using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Command.PricingCreateUpdate
{
    
    public class PricingCreateUpdateCommandValidator : AbstractValidator<PricingCreateUpdateCommand>
    {
        public PricingCreateUpdateCommandValidator()
        {
            RuleFor(pricing => pricing.Data.Region).NotEmpty().When(pricing => pricing.Data.Id == null || pricing.Data.Id == 0);
            RuleFor(pricing => pricing.Data.DestinationId).NotEmpty().When(pricing => pricing.Data.Id == null || pricing.Data.Id == 0);
            RuleFor(pricing => pricing.Data.VendorId).NotEmpty().When(pricing => pricing.Data.Id == null || pricing.Data.Id == 0);
            RuleFor(pricing => pricing.Data.FleetId).NotEmpty().When(pricing => pricing.Data.Id == null || pricing.Data.Id == 0);
            RuleFor(pricing => pricing.Data.Price).NotEmpty().When(pricing => pricing.Data.Id == null || pricing.Data.Id == 0);
            RuleFor(pricing => pricing.Data.TransportModeId).NotEmpty().When(pricing => pricing.Data.Id == null || pricing.Data.Id == 0);
        }
    }
}
