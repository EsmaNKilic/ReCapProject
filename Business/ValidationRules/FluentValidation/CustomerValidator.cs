using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customers>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.CompanyName).NotEmpty().WithMessage("Kampanya ismi boş bırakılamaz.");
        }
    }
}
