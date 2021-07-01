using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.Description).MinimumLength(10);
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.ModelYear).GreaterThan(1769);
            RuleFor(c => c.Description).Must(StarWith1).WithMessage("Açıklamalar 1 ile başlamalı!");
        }

        private bool StarWith1(string arg)
        {
            return arg.StartsWith("1");
        }
    }
}
