using Blog.Application.DataTransfer;
using Blog.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Validators.ArticleValidators
{
    public class CreateArticleValidator:AbstractValidator<ArticlesDto>
    {

        public CreateArticleValidator(BlogContext context)
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject must be filled");
            RuleFor(x => x.Text).NotEmpty().WithMessage("Post must containt text");
            RuleFor(x => x.Pictures.src).NotEmpty().WithMessage("Picture must be inserted");
            

        }
    }
}
