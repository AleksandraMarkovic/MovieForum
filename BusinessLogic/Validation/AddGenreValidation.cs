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
    public class AddGenreValidation : AbstractValidator<Genre>
    {
        public AddGenreValidation(MoviesContext context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Genre name is required").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must(x => !context.Genres.Any(y => y.Name == x && y.DeletedAt == null))
                .WithMessage("Genre already exists!");
            });
        }
    }
}
