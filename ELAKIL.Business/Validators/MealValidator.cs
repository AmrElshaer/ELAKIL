using ELAKIL.Business.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELAKIL.Business.Validators
{
    public class MealValidator : AbstractValidator<Meal>
    {
        public MealValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Price).NotEmpty();
        }
    }
}
