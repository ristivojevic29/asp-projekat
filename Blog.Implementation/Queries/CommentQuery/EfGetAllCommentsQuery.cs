using Blog.Application.DataTransfer;
using Blog.Application.Queries.Comment;
using Blog.Application.Queries.Pagination;
using Blog.Application.Searches;
using Blog.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Blog.Application;

namespace Blog.Implementation.Queries.CommentQuery
{
    public class EfGetAllCommentsQuery : IGetAllCommentsQuery
    {
        private readonly BlogContext _context;
        private readonly IApplicationActor _actor;
        public EfGetAllCommentsQuery(BlogContext context,IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }
        public int Id => 18;

        public string Name => "Get all comments";

        public PagedResponse<CommentDto> Execute(CommentSearch search)
        {
            var query = _context.Comments.AsQueryable();
         
            if (!string.IsNullOrEmpty(search.Username) || !string.IsNullOrWhiteSpace(search.Username))
            {
                query = query.Where(x => x.User.Username.ToLower().Contains(search.Username.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);
            var response = new PagedResponse<CommentDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new CommentDto
                {
                  text=x.Text,
                  ArticleId=x.ArticleId,
                  UserId=x.UserId,
                  User=new UserDto
                  {
                      Username=x.User.Username
                  }
                  
                }).ToList()
            };

            return response;
        }
    }
}
