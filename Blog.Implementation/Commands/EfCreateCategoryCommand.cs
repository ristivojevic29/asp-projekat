
using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.Domain.Entity;
using Blog.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Blog.Implementation.Validators.CategoryValidators;
using FluentValidation;
using System.Runtime.CompilerServices;
using Blog.Application;

namespace Blog.Implementation.Commands
{
    public class EfCreateCategoryCommand : ICreateCategoryCommand
    {
        private readonly BlogContext _context;
      
        private readonly CreateCategoryValidator _validator;
        private readonly IApplicationActor _actor;
        public EfCreateCategoryCommand(BlogContext context,CreateCategoryValidator validator,IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 1;

        public string Name => "Create new category";

        public void Execute(CategoryDto request)

        {
            _validator.ValidateAndThrow(request);
            var category = new Category
            {
               
                Name = request.Name
            };

            _context.Add(category);
            _context.SaveChanges();
        }
    }
}
