using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Command.DriverCreateUpdate
{
    
    public class DriverCreateUpdateCommandValidator : AbstractValidator<DriverCreateUpdateCommand>
    {
        public DriverCreateUpdateCommandValidator()
        {
            RuleFor(driver => driver.Data.FullName).NotEmpty();
            RuleFor(driver => driver.Data.Phone).NotEmpty();
            RuleFor(driver => driver.Data.VendorName).NotEmpty();
            RuleFor(driver => driver.Data.Password).NotEmpty().When(driver => driver.Data.Id == null || driver.Data.Id == 0);
            RuleFor(driver => driver.Data.ConfPassword).NotEmpty().When(driver => driver.Data.Id == null || driver.Data.Id == 0);
            RuleFor(driver => driver.Data.Password).Equal(driver => driver.Data.ConfPassword).WithMessage("Konfirmasi password tidak sesuai").When(driver => driver.Data.Id == null || driver.Data.Id == 0);
        }
    }
}
