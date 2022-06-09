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
    public class MovieValidation : AbstractValidator<Movie>
    {
        public MovieValidation(MoviesContext context)
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
            RuleFor(x => x.Year).NotEmpty().WithMessage("Year is required.");
            RuleFor(x => x.Duration).NotEmpty().WithMessage("Duration is required.");
            RuleFor(x => x.Poster).NotEmpty().WithMessage("Poster is required.");
            RuleFor(x => x.CoverImg).NotEmpty().WithMessage("Cover image is required.");
            RuleFor(x => x.Popularity).NotEmpty().WithMessage("Popularity is required.");

            RuleFor(x => x.CountryId).NotEmpty().WithMessage("Country is required.").DependentRules(() =>
            {
                RuleFor(x => x.CountryId).Must(x => context.Countries.Any(y => y.Id == x)).WithMessage("Country does not exist.");
            });
            RuleFor(x => x.TypeId).NotEmpty().WithMessage("Type is required.").DependentRules(() =>
            {
                RuleFor(x => x.TypeId).Must(x => context.Types.Any(y => y.Id == x)).WithMessage("Type does not exist.");
            });

            RuleFor(x => x.MovieGenres).NotEmpty().WithMessage("Genres are required.").DependentRules(() =>
            {
                RuleFor(x => x.MovieGenres).Must(movieGenres =>
                {
                    var distinct = movieGenres.Select(x => x.GenreId).Distinct();
                    return distinct.Count() == movieGenres.Count();
                }).WithMessage("There are duplicate genres.").DependentRules(() =>
                {
                    RuleForEach(x => x.MovieGenres).SetValidator(new MovieGenreValidation(context));
                });
            });

            RuleFor(x => x.Finances).NotEmpty().WithMessage("Finances are required.").DependentRules(() =>
            {
                RuleForEach(x => x.Finances).SetValidator(new FinancesValidation(context));
            });
        }
    }
}
