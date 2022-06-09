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
    public class AddCountryValidation : AbstractValidator<Country>
    {
        public AddCountryValidation(MoviesContext context)
        {
            RuleFor(x => x.CountryName).NotEmpty().WithMessage("Country name is required.").DependentRules(() =>
            {
                RuleFor(x => x.CountryName).Must(x => !context.Countries.Any(y => y.CountryName == x))
                .WithMessage("Country name already exists.");
            });
        }
    }
}
