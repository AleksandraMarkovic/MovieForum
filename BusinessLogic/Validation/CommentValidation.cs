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
    public class CommentValidation : AbstractValidator<Comment>
    {
        public CommentValidation(MoviesContext context)
        {
            RuleFor(x => x.CommentText).NotEmpty().WithMessage("Comment is required.");
        }
    }
}
