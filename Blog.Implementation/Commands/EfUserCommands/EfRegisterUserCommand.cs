using Blog.Application.Commands.UserCommands;
using Blog.Application.DataTransfer;
using Blog.Application.Email;
using Blog.Domain.Entity;
using Blog.EfDataAccess;
using Blog.Implementation.Validators.UserValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace Blog.Implementation.Commands.EfUserCommands
{
    public class EfRegisterUserCommand : IRegisterUserCommand
    {
        private readonly BlogContext _context;
        private readonly IEmailSender _sender;
        private readonly RegisterUserValidator _validator;
        public EfRegisterUserCommand(BlogContext context,IEmailSender sender,RegisterUserValidator validator)
        {
            _context = context;
            _sender = sender;
            _validator = validator;
        }
        public int Id => 11;

        public string Name => "Register user";

        public void Execute(RegisterDto request)
        {
            var cases = new List<int> { 5, 8, 9, 16, 17, 18, 20 ,23};
            _validator.ValidateAndThrow(request);
           
           
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.Username,
                Email = request.Email,
                Password = request.Password
                //UserUseCases=useCases
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            _sender.Send(new SendMailDto
            {
                Subject="Registration",
                Content="Successfully registration",
                SendTo=request.Email
            });
          
            foreach (var i in cases)
            {
                var userUseCases = new UserUseCase
                {
                    UseCaseId = i,
                    UserId=user.Id

                };
                _context.Add(userUseCases);
            }
            _context.SaveChanges();
        }
    }
}
