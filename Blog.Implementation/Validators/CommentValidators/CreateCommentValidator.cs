using Blog.Application.DataTransfer;
using Blog.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Validators.CommentValidators
{
    public class CreateCommentValidator:AbstractValidator<CommentDto>
    {
        public CreateCommentValidator(BlogContext context)
        {
            RuleFor(x => x.text).NotEmpty();
           
        }
    }
}
