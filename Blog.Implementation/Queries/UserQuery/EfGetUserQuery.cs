using Blog.Application;
using Blog.Application.DataTransfer;
using Blog.Application.Queries.User;
using Blog.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Queries.UserQuery
{
    public class EfGetUserQuery : IGetUserQuery
    {
        private readonly BlogContext _context;
        private readonly IApplicationActor _actor;
        public EfGetUserQuery(BlogContext context,IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }
        public int Id => 14;

        public string Name => "Get one user";

        public UserDto Execute(int search)
        {
            var user = _context.Users.Find(search);

            var response = new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Email = user.Email
            };
            return response;
        }
    }
}
