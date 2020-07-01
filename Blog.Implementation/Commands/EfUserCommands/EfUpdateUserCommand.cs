using Blog.Application;
using Blog.Application.Commands.UserCommands;
using Blog.Application.DataTransfer;
using Blog.EfDataAccess;
using Blog.Implementation.Validators.UserValidators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands.EfUserCommands
{
    public class EfUpdateUserCommand : IUpdateUserCommand
    {
        private readonly BlogContext _context;
        private readonly IApplicationActor _actor;
        private readonly UpdateUserValidator _validator;
        public EfUpdateUserCommand(BlogContext context,IApplicationActor actor,UpdateUserValidator validator)
        {
            _context = context;
            _actor = actor;
            _validator = validator;
        }
        public int Id =>13;

        public string Name => "Upadate user";

        public void Execute(UserDto request, int id)
        {
            _validator.ValidateAndThrow(request);
            var user = _context.Users.Find(id);

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Username = request.Username;
            user.Email = request.Email;

            _context.SaveChanges();
        }
    }
}
