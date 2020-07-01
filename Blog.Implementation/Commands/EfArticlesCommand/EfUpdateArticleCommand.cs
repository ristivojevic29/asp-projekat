using Blog.Application;
using Blog.Application.Commands.ArticleCommands;
using Blog.Application.DataTransfer;
using Blog.Domain.Entity;
using Blog.EfDataAccess;
using Blog.Implementation.Validators.ArticleValidators;
using FluentValidation;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Blog.Implementation.Commands.EfArticlesCommand
{
    public class EfUpdateArticleCommand : IUpdateArticleCommand
    {
        private readonly BlogContext _context;
        private readonly UpdateArticleValidtor _validator;
        private readonly IApplicationActor _actor;
        public EfUpdateArticleCommand(BlogContext context,UpdateArticleValidtor validator,IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 10;

        public string Name => "Update article";

        public void Execute(ArticlesDto request, int id)
        {
            _validator.ValidateAndThrow(request);
            var post = _context.Articles.Find(id);
            var pic = _context.Pictures.Find(post.PicturesId);
            var postcat = _context.ArticleCategories.Where(x=>x.ArticlesId==id).Select(x=>x.Id).ToList();

            post.Subject = request.Subject;
            post.Text = request.Text;
            post.UserId = request.UserId;
            pic.src = request.Pictures.src;
          //  pic.alt = request.Pictures.alt;

            post.Pictures.ModifiedAt = DateTime.Now;
            post.ModifiedAt = DateTime.Now;
            var brojKategorije = request.Categories;
            foreach(var i in postcat)
            {
                var pc = _context.ArticleCategories.Find(i);
                _context.ArticleCategories.Remove(pc);
            }
                      
            foreach(var bk in brojKategorije)
            {
                
                var cat = new ArticleCategories
                {
                    ArticlesId = id,
                    CategoryId = bk.Id
                };
                _context.ArticleCategories.Add(cat);
                
            }
            _context.SaveChanges();
        }
    }
}
