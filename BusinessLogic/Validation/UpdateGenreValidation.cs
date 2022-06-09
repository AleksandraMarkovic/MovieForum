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
    public class UpdateGenreValidation : AbstractValidator<Genre>
    {
        public UpdateGenreValidation(MoviesContext context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must(x => !context.Genres.Any(y => y.Name == x)).WithMessage("Name already exists.");
            });
        }
    }
}
