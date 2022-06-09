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
    public class AddUserValidation : AbstractValidator<User>
    {
        public AddUserValidation(MoviesContext context)
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.").DependentRules(() =>
            {
                RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not in correct form.").DependentRules(() =>
                {
                    RuleFor(x => x.Email).Must(x => !context.Users.Any(y => y.Email == x)).WithMessage("Email already exists.");
                });
            });
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required.").DependentRules(() =>
            {
                RuleFor(x => x.Username).Must(x => !context.Users.Any(y => y.Username == x)).WithMessage("Username already exists.");
            });
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.");
            RuleFor(x => x.Birthday).NotEmpty().WithMessage("Birthday is required.");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Image is required.");
        }
    }
}
