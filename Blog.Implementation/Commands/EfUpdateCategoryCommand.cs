using Blog.Application;
using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.EfDataAccess;
using Blog.Implementation.Validators.CategoryValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EfUpdateCategoryCommand : IUpdateCategoryCommand
    {
        private readonly BlogContext _context;
        private readonly CreateCategoryValidator _validator;
        private readonly IApplicationActor _actor;
        public EfUpdateCategoryCommand(BlogContext context,CreateCategoryValidator validator,IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id =>4;

        public string Name => "Update category name";

        public void Execute(CategoryDto request, int id)
        {
            _validator.ValidateAndThrow(request);
            var categories = _context.Categories.Find(id);

            if (categories == null)
            {

            }

            categories.Name = request.Name;
            categories.ModifiedAt = DateTime.Now;
            _context.SaveChanges();

        
        }
    }
}
