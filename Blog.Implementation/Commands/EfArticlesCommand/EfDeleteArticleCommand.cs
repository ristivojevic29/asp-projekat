using Blog.Application.Commands.ArticleCommands;
using Blog.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Blog.Application;

namespace Blog.Implementation.Commands.EfArticlesCommand
{
    public class EfDeleteArticleCommand : IDeleteArticleCommand
    {
        private readonly BlogContext _context;
        private readonly IApplicationActor _actor;
        public EfDeleteArticleCommand(BlogContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }
        public int Id =>7;

        public string Name => "Delete Post";

        public void Execute(int request)
        {
            var post = _context.Articles.Find(request);

            post.IsDeleted = true;
            post.IsActive = false;
            post.DeletedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
