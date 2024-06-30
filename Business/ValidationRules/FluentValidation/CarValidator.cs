using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator :AbstractValidator<Car>
    {
        public CarValidator()
        {
            //car.Description.Length > 2 && Int32.Parse(car.DailyPrice) > 0
            RuleFor(c => c.Name).MinimumLength(2);
            RuleFor(c=>c.Description).MinimumLength(2);
            RuleFor(c => Int32.Parse(c.DailyPrice)).GreaterThanOrEqualTo(1);
            RuleFor(c => c.ModelYear).Equal("2023").When(c => c.ColorId == 2);
            RuleFor(c => c.ModelYear).Must(StartsWithTwo).WithMessage(Messages.ModelYearMustStartTwo);

        }

        private bool StartsWithTwo(string arg)
        {
            return arg.StartsWith("2");
        }
    }
}
