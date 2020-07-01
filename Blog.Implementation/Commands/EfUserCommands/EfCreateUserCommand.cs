using Blog.Application;
using Blog.Application.Commands.UserCommands;
using Blog.Application.DataTransfer;
using Blog.Domain.Entity;
using Blog.EfDataAccess;
using Blog.Implementation.Validators.UserValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands.EfUserCommands
{
    public class EfCreateUserCommand : ICreateUserCommand
    {
        private readonly BlogContext _context;
        private readonly IApplicationActor _actor;
        private readonly CreateUserValidator _validator;
        public EfCreateUserCommand(BlogContext context,IApplicationActor actor, CreateUserValidator validator)
        {
            _context = context;
            _actor = actor;
            _validator = validator;
        }
        public int Id => 22;

        public string Name => "Create user by admin";

        public void Execute(UserDto request)
        {
            var cases = new List<int> { 5, 8, 9, 16, 17, 18, 20 ,23};
            _validator.Validate(request);


            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.Username,
                Email = request.Email,
                Password = request.Password
               
            };
            _context.Users.Add(user);
            _context.SaveChanges();
           
            foreach (var i in cases)
            {
                var userUseCases = new UserUseCase
                {
                    UseCaseId = i,
                    UserId = user.Id

                };
                _context.Add(userUseCases);
            }
            _context.SaveChanges();
        }
    }
    
}
