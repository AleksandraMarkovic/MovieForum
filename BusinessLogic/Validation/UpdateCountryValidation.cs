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
    public class UpdateCountryValidation : AbstractValidator<Country>
    {
        public UpdateCountryValidation(MoviesContext context)
        {
            RuleFor(x => x.CountryName).NotEmpty().WithMessage("Country name is required.").DependentRules(() =>
            {
                RuleFor(x => x.CountryName).Must((country, name) => !context.Countries.Any(y => y.CountryName == name && y.Id != country.Id))
                .WithMessage("Country name already exists.");
            });
        }
    }
}
