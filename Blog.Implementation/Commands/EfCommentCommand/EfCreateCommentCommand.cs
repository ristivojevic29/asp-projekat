using Blog.Application;
using Blog.Application.Commands.CommentCommands;
using Blog.Application.DataTransfer;
using Blog.Domain.Entity;
using Blog.EfDataAccess;
using Blog.Implementation.Validators.CommentValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands.EfCommentCommand
{
    public class EfCreateCommentCommand : ICreateCommentCommand
    {
        private readonly BlogContext _context;
        private readonly IApplicationActor _actor;
        private readonly CreateCommentValidator _validator;
        public EfCreateCommentCommand(BlogContext context,IApplicationActor actor,CreateCommentValidator validator)
        {
            _context = context;
            _actor = actor;
            _validator = validator;
        }
        public int Id => 16;

        public string Name => "Comment post";

        public void Execute(CommentDto request, int id)
        {
            _validator.ValidateAndThrow(request);
            var comment = new Comment
            {
                Text = request.text,
                ArticleId = id,
                UserId = _actor.Id
            };
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

    }
}
