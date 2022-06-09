using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validation
{
    public class AddMovieValidation : MovieValidation
    {
        public AddMovieValidation(MoviesContext context) : base(context)
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Movie title is required.").DependentRules(() =>
            {
                RuleFor(x => x.Title).Must(x => !context.Movies.Any(y => y.Title == x)).WithMessage("Movie title already exists.");
            });
        }
    }
}
