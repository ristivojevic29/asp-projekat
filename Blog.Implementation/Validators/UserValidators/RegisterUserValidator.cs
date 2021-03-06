﻿using Blog.Application.DataTransfer;
using Blog.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Linq;

namespace Blog.Implementation.Validators.UserValidators
{
    public class RegisterUserValidator:AbstractValidator<RegisterDto>
    {
        public RegisterUserValidator(BlogContext context)
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
