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
    public class MovieGenreValidation : AbstractValidator<MovieGenre>
    {
        public MovieGenreValidation(MoviesContext context)
        {
            RuleFor(x => x.GenreId).NotEmpty().WithMessage("Genre is required.").DependentRules(() =>
            {
                RuleFor(x => x.GenreId).Must(x => context.Genres.Any(y => y.Id == x)).WithMessage("Genre does not exist.");
            });
        }
    }
}
