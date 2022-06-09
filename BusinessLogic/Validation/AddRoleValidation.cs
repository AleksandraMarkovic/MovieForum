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
    public class AddRoleValidation : AbstractValidator<Role>
    {
        public AddRoleValidation(MoviesContext context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Role name is required.").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must(x => !context.Roles.Any(y => y.Name == x)).WithMessage("Role already exists.");
            });
        }
    }
}
