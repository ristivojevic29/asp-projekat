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

            _validator.ValidateAndThrow(request);
            HashSet<UserUseCase> useCases = new HashSet<UserUseCase>();
            foreach(var i in request.UseCasesId)
            {
                var userUseCases = new UserUseCase
                {
                    UseCaseId = i
                };
                _context.Add(userUseCases);
            }
           
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.Username,
                Email = request.Email,
                Password = request.Password,
                UserUseCases=useCases
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            _sender.Send(new SendMailDto
            {
                Subject="Registration",
                Content="Successfully registration",
                SendTo=request.Email
            });
        }
    }
}
