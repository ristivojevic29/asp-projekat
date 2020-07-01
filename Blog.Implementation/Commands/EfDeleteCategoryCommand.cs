using Blog.Application;
using Blog.Application.Commands;
using Blog.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EfDeleteCategoryCommand : IDeleteCategoryCommand
    {
        private readonly BlogContext _context;
        private readonly IApplicationActor _actor;
        public EfDeleteCategoryCommand(BlogContext context,IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }
        public int Id => 2;

        public string Name => "Delete category";

        public void Execute(int request)
        {
            var category = _context.Categories.Find(request);

            if (category == null)
            {

            }
            category.IsDeleted = true;
            category.IsActive = false;
            category.DeletedAt = DateTime.Now;
                _context.SaveChanges();
            
           
        }
    }
}
