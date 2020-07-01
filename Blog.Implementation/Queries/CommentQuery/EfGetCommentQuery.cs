using Blog.Application;
using Blog.Application.DataTransfer;
using Blog.Application.Queries.Comment;
using Blog.EfDataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;

namespace Blog.Implementation.Queries.CommentQuery
{
    public class EfGetCommentQuery : IGetCommentQuery
    {
        private readonly BlogContext _context;
        private readonly IApplicationActor _actor;
        public EfGetCommentQuery(BlogContext context,IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }
        public int Id =>19;

        public string Name => "Get comment";

        public CommentDto Execute(int search)
        {
            var comment = _context.Comments.Find(search);
            var user = _context.Users.Find(comment.UserId);
            var response = new CommentDto
            {
                text = comment.Text,
                ArticleId = comment.ArticleId,
                UserId=comment.UserId,
                User =new UserDto
                {
                    Username=user.Username
                }
            };
            return response;
        }
    }
}
