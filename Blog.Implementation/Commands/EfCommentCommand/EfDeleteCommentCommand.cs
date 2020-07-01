using Blog.Application;
using Blog.Application.Commands.CommentCommands;
using Blog.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands.EfCommentCommand
{
    public class EfDeleteCommentCommand : IDeleteCommentCommand
    {
        private readonly BlogContext _context;
        private readonly IApplicationActor _actor;
        public EfDeleteCommentCommand(BlogContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }
        public int Id => 17;

        public string Name => "Delete comment";

        public void Execute(int request)
        {
            var com = _context.Comments.Find(request);

            com.IsDeleted = true;
            com.IsActive = false;
            com.DeletedAt = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
