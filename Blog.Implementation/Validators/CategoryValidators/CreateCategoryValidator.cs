using Blog.Application.DataTransfer;
using Blog.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Blog.Implementation.Validators.CategoryValidators
{
    public class CreateCategoryValidator:AbstractValidator<CategoryDto>
    {
        public CreateCategoryValidator(BlogContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Must(name => !context.Categories.Any(d => d.Name == name))
                .WithMessage("Category name must be unique");
        }
    }
}
