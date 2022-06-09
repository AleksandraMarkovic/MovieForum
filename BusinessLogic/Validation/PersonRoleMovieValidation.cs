using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.DTOs.Person;

namespace BusinessLogic.Validation
{
    public class PersonRoleMovieValidation : AbstractValidator<PersonRoleMovie>
    {
        public PersonRoleMovieValidation(MoviesContext context)
        {
            RuleFor(x => x.MovieId).NotEmpty().WithMessage("Movie is required.").DependentRules(() =>
            {
                RuleFor(x => x.MovieId).Must(x => context.Movies.Any(y => y.Id == x)).WithMessage("Movie not found.");
            });
        }
    }
}
