using Blog.Application;
using Blog.Application.Commands.CommentCommands;
using Blog.Application.DataTransfer;
using Blog.EfDataAccess;
using Blog.Implementation.Validators.CommentValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands.EfCommentCommand
{
    public class EfUpdateComment : IUpdateCommentCommand
    {
        private readonly BlogContext _context;
        private readonly IApplicationActor _actor;
        private readonly CreateCommentValidator _validator;
        public EfUpdateComment(BlogContext context,IApplicationActor actor,CreateCommentValidator validator)
        {
            _context = context;
            _actor = actor;
            _validator = validator;
        }
        public int Id => 20;

        public string Name => "Update comment";

        public void Execute(CommentDto request, int id)
        {
            _validator.ValidateAndThrow(request);
            var comment = _context.Comments.Find(id);

            comment.Text = request.text;

            _context.SaveChanges();
        }
    }
}
