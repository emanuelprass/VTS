using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Command.PricingDelete
{
    public class PricingDeleteCommandValidator : AbstractValidator<PricingDeleteCommand>
    {
        public PricingDeleteCommandValidator()
        {
            RuleFor(pricing => pricing.Data.Id).NotEmpty();
        }
    }
}
