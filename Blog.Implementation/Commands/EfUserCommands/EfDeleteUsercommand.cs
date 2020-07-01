using Blog.Application;
using Blog.Application.Commands.UserCommands;
using Blog.EfDataAccess;
using Bogus.DataSets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands.EfUserCommands
{
    public class EfDeleteUserCommand : IDeleteUserCommand
    {
        private readonly BlogContext _context;
        private readonly IApplicationActor _actor;
        public EfDeleteUserCommand(BlogContext context,IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }
        public int Id =>12;

        public string Name => "Delete user";

        public void Execute(int request)
        {
            var user = _context.Users.Find(request);

            user.IsDeleted = true;
            user.IsActive = false;
            user.DeletedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
