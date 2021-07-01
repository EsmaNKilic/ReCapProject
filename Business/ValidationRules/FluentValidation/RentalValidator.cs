using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rentals>
    {
        public RentalValidator()
        { 
            RuleFor(r => r.RentDate).NotEmpty();
            //RuleFor(r => r.ReturnDate).Equal(null).WithMessage("Araç kiralanamaz!");
        }
    }
}
