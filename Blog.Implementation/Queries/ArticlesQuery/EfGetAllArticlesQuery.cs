using Blog.Application.DataTransfer;
using Blog.Application.Queries.ArticleQuery;
using Blog.Application.Searches;
using Blog.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Blog.Domain.Entity;
using Blog.Application;
using System.Security.Cryptography.X509Certificates;
using Blog.Application.Queries.Pagination;

namespace Blog.Implementation.Queries.ArticlesQuery
{
    public class EfGetAllArticlesQuery : IGetAllArticlesQuery
    {
        private readonly BlogContext _context;
        public EfGetAllArticlesQuery(BlogContext context)
        {
            _context = context;
        }
        public int Id => 9;

        public string Name => "Get all articles and search them";

        public PagedResponse<ArticlesDto> Execute(ArticleSearch search)
        {
            var query = _context.Articles.AsQueryable();
            if (!string.IsNullOrEmpty(search.Subject) || !string.IsNullOrWhiteSpace(search.Subject))
            {
                query = query.Where(x => x.Subject.ToLower().Contains(search.Subject.ToLower()));
            }

            var sb = query.Select(x => x.Id);
          
            var categories = _context.ArticleCategories.Where(x => sb.Contains(x.ArticlesId));
           
            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<ArticlesDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new ArticlesDto
                {
                    Id = x.Id,
                    Subject = x.Subject,
                    Text = x.Text,
                    PicturesId = x.PicturesId,
                    UserId=x.UserId,
                    User =new UserDto { 
                        FirstName=x.User.FirstName,
                        LastName=x.User.LastName,
                        Username=x.User.Username
                    },
                    
                    Pictures = new PicturesDto
                    {
                        src = x.Pictures.src
                      //  alt = x.Pictures.alt
                    },
                    Categories = categories.Where(d => d.ArticlesId == x.Id).Select(c => new CategoryDto
                    {
                        Id = c.CategoryId,
                        Name = c.Categories.Name
                    }).ToList()
                   
                })

            };
            return response;

        }
    }
}
