using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Colors>
    {
        public ColorValidator()
        {
            RuleFor(c => c.Name).MaximumLength(9).WithMessage("Renk ismi en fazla 9 harften oluşur.");
        }
    }
}
