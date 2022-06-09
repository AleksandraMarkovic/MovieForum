using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validation
{
    public class AddTypeValidation : AbstractValidator<Application.DTOs.Type>
    {
        public AddTypeValidation(MoviesContext context)
        {
            RuleFor(x => x.MovieType).NotEmpty().WithMessage("Type is required.").DependentRules(() =>
            {
                RuleFor(x => x.MovieType).Must(x => !context.Types.Any(y => y.MovieType == x)).WithMessage("Type already exists.");
            });
        }
    }
}
