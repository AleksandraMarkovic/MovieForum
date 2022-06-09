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
    public class UpdateRoleValidation : AbstractValidator<Role>
    {
        public UpdateRoleValidation(MoviesContext context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Role name is required.").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must((role, name) => !context.Roles.Any(y => y.Name == name && y.Id != role.Id))
                .WithMessage("Role already exists.");
            });
        }
    }
}
