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
    public class UpdateUserValidation : AbstractValidator<User>
    {
        public UpdateUserValidation(MoviesContext context)
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.").DependentRules(() =>
            {
                RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not in correct form.").DependentRules(() =>
                {
                    RuleFor(x => x.Email).Must((user, email) => !context.Users.Any(y => y.Email == email && y.Id != user.Id))
                    .WithMessage("Email already exists.");
                });
            });
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required.").DependentRules(() =>
            {
                RuleFor(x => x.Username).Must((user, username) => !context.Users.Any(y => y.Username == username && y.Id != user.Id))
                .WithMessage("Username already exists.");
            });
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Image is required.");
        }
    }
}
