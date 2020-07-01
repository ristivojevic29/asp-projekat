using Blog.Application.DataTransfer;
using Blog.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Blog.Implementation.Validators.ArticleValidators
{
    public class UpdateArticleValidtor:AbstractValidator<ArticlesDto>
    {
        public UpdateArticleValidtor(BlogContext context)
        {
            RuleFor(x => x.Subject).NotEmpty().NotNull();
            RuleFor(x => x.Text).NotEmpty().NotNull();
            RuleFor(x => x.Pictures.src).NotEmpty().WithMessage("Picture must be inserted");
            RuleFor(x => x.Categories).NotNull();
        }
    }
}
