using Blog.Application.Commands.ArticleCommands;
using Blog.Application.DataTransfer;
using Blog.Domain.Entity;
using Blog.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Blog.Implementation.Validators.ArticleValidators;
using FluentValidation;
using Bogus.DataSets;
using System.ComponentModel.DataAnnotations;
using Blog.Application;
using System.IO;

namespace Blog.Implementation.Commands.EfArticlesCommand
{
    public class EfCreateArticleCommand : ICreateArticleCommand
    {
        private readonly BlogContext _context;
        private readonly CreateArticleValidator _validator;
        private readonly IApplicationActor _actor;
        public EfCreateArticleCommand(BlogContext context,CreateArticleValidator validator,IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 6;

        public string Name => "Create new post";

        public void Execute(ArticlesDto request, PicturesDto image)
        {
            _validator.ValidateAndThrow(request);
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(image.Image.FileName);

            var newFileName = guid + extension;

            var path = Path.Combine("wwwroot", "images", newFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                image.Image.CopyTo(fileStream);
            }

            var pictures = new Pictures
            {
                src = newFileName
               
            };
            _context.Pictures.Add(pictures);
            _context.SaveChanges();
            var article = new Article
            {
                Subject = request.Subject,
                Text = request.Text,
                PicturesId = pictures.Id,
                UserId = _actor.Id
            };
            _context.Articles.Add(article);
            _context.SaveChanges();
            foreach (var c in request.Categories)
            {

                var categories = new ArticleCategories
                {
                    ArticlesId = article.Id,
                    CategoryId = c.Id
                };
                _context.ArticleCategories.Add(categories);
                _context.SaveChanges();
            }

        }
    }
}
