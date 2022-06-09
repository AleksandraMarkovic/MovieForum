using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validation
{
    public class UpdateTypeValidation : AbstractValidator<Application.DTOs.Type>
    {
        public UpdateTypeValidation(MoviesContext context)
        {
            RuleFor(x => x.MovieType).NotEmpty().WithMessage("Type is required.").DependentRules(() =>
            {
                //Checks if any type, excluding the one you're updating, has the emtered name
                RuleFor(x => x.MovieType).Must((type, name) => !context.Types.Any(y => y.MovieType == name && y.Id != type.Id))
                .WithMessage("Type already exists.");
            });
        }
    }
}
