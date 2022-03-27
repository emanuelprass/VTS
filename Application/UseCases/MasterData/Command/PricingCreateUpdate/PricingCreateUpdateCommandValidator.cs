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
            RuleFor(pricing => pricing.Data.Region).NotEmpty();
            RuleFor(pricing => pricing.Data.DestinationCode).NotEmpty();
            RuleFor(pricing => pricing.Data.VendorCode).NotEmpty();
            RuleFor(pricing => pricing.Data.ModelName).NotEmpty();
            RuleFor(pricing => pricing.Data.Price).NotEmpty();
            RuleFor(pricing => pricing.Data.DeliveryMode).NotEmpty();
        }
    }
}
