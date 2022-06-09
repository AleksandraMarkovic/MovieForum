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
    public class PersonValidation : AbstractValidator<Person>
    {
        public PersonValidation(MoviesContext context)
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");
            RuleFor(x => x.Bio).NotEmpty().WithMessage("Bio is required.");
            RuleFor(x => x.PlaceOfBirth).NotEmpty().WithMessage("Place of birth is required.");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Image is required.");

            RuleFor(x => x.PersonRoleMovies).NotEmpty().WithMessage("Role and movies are required.").DependentRules(() =>
            {
                //Checks if the same movie and role are inserted more than once
                RuleFor(x => x.PersonRoleMovies).Must(personRoleMovies =>
                    personRoleMovies.Select(y => y.MovieId + y.RoleId).Distinct().Count() == personRoleMovies.Count())
                .WithMessage("There are duplicate roles and movies.").DependentRules(() =>
                {
                    RuleForEach(x => x.PersonRoleMovies).SetValidator(new PersonRoleMovieValidation(context));
                });
            });
        }
    }
}
