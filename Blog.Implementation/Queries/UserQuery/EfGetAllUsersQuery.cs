using Blog.Application.DataTransfer;
using Blog.Application.Queries.User;
using Blog.Application.Searches;
using Blog.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Blog.Application.Queries.Pagination;
using Blog.Application;

namespace Blog.Implementation.Queries.UserQuery
{
    public class EfGetAllUsersQuery : IGetAllUsersQuery
    {
        private readonly BlogContext _context;
        private readonly IApplicationActor _actor;
        public EfGetAllUsersQuery(BlogContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }
        public int Id => 15;

        public string Name => "Get all users";

        public PagedResponse<UserDto> Execute(UserSearch search)
        {
            var query = _context.Users.AsQueryable();
            if (!string.IsNullOrEmpty(search.Username) || !string.IsNullOrWhiteSpace(search.Username))
            {
                query = query.Where(x => x.Username.ToLower().Contains(search.Username.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);
            var response = new PagedResponse<UserDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new UserDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Username = x.Username,
                    Email = x.Email

                }).ToList()
            };
             
            return response;
        }
    }
}
