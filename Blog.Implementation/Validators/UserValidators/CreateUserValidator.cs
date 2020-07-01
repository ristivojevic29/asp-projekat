using Blog.Application.DataTransfer;
using Blog.EfDataAccess;
using Blog.EfDataAccess.Configuration;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Blog.Implementation.Validators.UserValidators
{
    public class CreateUserValidator:AbstractValidator<UserDto>
    {
        public CreateUserValidator(BlogContext context)
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Username).NotEmpty()
                .MinimumLength(4)
                .Must(x => !context.Users.Any(u => u.Username == x))
                .WithMessage("Username must be unique");
            RuleFor(x => x.Email).NotEmpty()
                 .EmailAddress()
                .Must(x => !context.Users.Any(e => e.Email == x))

                .WithMessage("Email must be unique");

            RuleFor(x => x.Password).NotEmpty()
                .MinimumLength(5);
        }
    }
}
