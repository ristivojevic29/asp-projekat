using AutoMapper;
using Blog.Application;
using Blog.Application.DataTransfer;
using Blog.Application.Queries;
using Blog.Domain.Entity;
using Blog.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Blog.Implementation.Queries
{
    public class EfGetCategoryQuery : IGetCategoryQuery
    {
        private readonly BlogContext _context;
        private readonly IApplicationActor _actor;
        public EfGetCategoryQuery(BlogContext context,IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }
        public int Id => 4;

        public string Name => "Search category by id";

        public CategoryDto Execute(int search)
        {
            var category = _context.Categories.Find(search);

            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
            return response;
        }
    }
}
