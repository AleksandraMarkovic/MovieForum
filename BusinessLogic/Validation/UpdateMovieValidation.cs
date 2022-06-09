using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validation
{
    public class UpdateMovieValidation : MovieValidation
    {
        public UpdateMovieValidation(MoviesContext context) : base(context)
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Movie title is required.").DependentRules(() =>
            {
                RuleFor(x => x.Title).Must((movie, title) => !context.Movies.Any(y => y.Title == title && y.Id != movie.Id))
                .WithMessage("Movie title already exists.");
            });
        }
    }
}
