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
    public class WatchlistValidation : AbstractValidator<Watchlist>
    {
        public WatchlistValidation(MoviesContext context)
        {
            RuleFor(x => x.MovieId).NotEmpty().WithMessage("Movie is required.").DependentRules(() =>
            {
                RuleFor(x => x.MovieId).Must(x => context.Movies.Any(y => y.Id == x)).WithMessage("Movie does not exist.");
            });

            
        }
    }
}
