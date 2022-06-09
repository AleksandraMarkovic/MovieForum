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
    public class RatingValidation : AbstractValidator<Rating>
    {
        public RatingValidation(MoviesContext context)
        {
            RuleFor(x => x.RatingValue).NotEmpty().WithMessage("Rating is required").DependentRules(() =>
            {
                RuleFor(x => x.RatingValue).Must(x => x > 0 && x <= 5).WithMessage("Rating must be between 1 and 5.");
            });
        }
    }
}
