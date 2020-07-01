using Blog.Application;
using Blog.Application.DataTransfer;
using Blog.Application.Queries;
using Blog.Application.Searches;
using Blog.Domain.Entity;
using Blog.EfDataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace Blog.Implementation.Queries
{
    public class EfGetAllCategoriesQuery : IGetAllCategoriesQuery
    {
        public readonly BlogContext _context;
        public EfGetAllCategoriesQuery(BlogContext context)
        {
            _context = context;
        }

        public int Id => 5;

        public string Name => "category search";

        public IEnumerable<CategoryDto> Execute(CategorySearch search)
        {
            var query = _context.Categories.AsQueryable();
            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }
            return query.Select(x => new CategoryDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
