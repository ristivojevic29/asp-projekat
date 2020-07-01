using Blog.Application.DataTransfer;
using Blog.Application.Queries.ArticleQuery;
using Blog.Domain.Entity;
using Blog.EfDataAccess;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Blog.Implementation.Queries.ArticlesQuery
{
    public class EfGetArticleCommand : IGetArticleQuery
    {
        private readonly BlogContext _context;
        public EfGetArticleCommand(BlogContext context)
        {
            _context = context;
        }
        public int Id =>8;

        public string Name => "Get one post";

        public ArticlesDto Execute(int search)
        {

            var post = _context.Articles.Find(search);
            var categories = _context.ArticleCategories.Where(x => x.ArticlesId == search).Select(x => x.CategoryId).ToList();
            var pic = _context.Pictures.Find(post.PicturesId);
            var user = _context.Users.Find(post.UserId);
            var cat = _context.Categories.Where(x => categories.Contains(x.Id));
            var ct = cat.Select(d => new CategoryDto
            {
                Id = d.Id,
                Name = d.Name
            }).ToList();
            var response = new ArticlesDto
            {
                Id = post.Id,
                Subject = post.Subject,
                Text = post.Text,
                PicturesId=post.PicturesId,
                UserId=post.UserId,
                User=new UserDto
                {
                    FirstName= user.FirstName,
                    LastName=user.LastName,
                    Username=user.Username
                },
                Pictures =new PicturesDto { 
                    src=pic.src
                   // alt=pic.alt
                },
                Categories = ct
            };
            return response;
        }
    }
}
