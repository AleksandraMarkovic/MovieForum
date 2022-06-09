using Application.DTOs;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validation
{
    public class FinancesValidation : AbstractValidator<Finance>
    {
        public FinancesValidation(MoviesContext context)
        {
            RuleFor(x => x.Budget).NotEmpty().WithMessage("Budget is required.").DependentRules(() =>
            {
                RuleFor(x => x.Budget).GreaterThan(0).WithMessage("Budget value must be greater than zero.");
            });
        }
    }
}
