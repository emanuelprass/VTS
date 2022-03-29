using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Command.PricingCreateUpdate
{
    
    public class PricingCreateUpdateCommandValidator : AbstractValidator<CreateDto>
    {
        public PricingCreateUpdateCommandValidator()
        {
            RuleFor(pricing => pricing.Region).NotEmpty();
            RuleFor(pricing => pricing.DestinationCode).NotEmpty();
            RuleFor(pricing => pricing.VendorCode).NotEmpty();
            // RuleFor(pricing => pricing.ModelName).NotEmpty();
            RuleFor(pricing => pricing.Price).NotEmpty();
            RuleFor(pricing => pricing.DeliveryMode).NotEmpty();
        }
    }
}
