using Blog.Application;
using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.Domain.Entity;
using Blog.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EfRateCommand : IRateArticle
    {
        private readonly BlogContext _context;
        private readonly IApplicationActor _actor;

        public EfRateCommand(BlogContext context,IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }
        public int Id => 23;

        public string Name => "Rate article";

        public void Execute(RateDto request, int id)
        {
            var userRateArticle = _context.Rates.Where(x=>x.ArticleId==request.ArticleId).Select(s=>s.UserId);

            
            if (request.RateNumber > 5  )
            {
                throw new ArgumentException("Number must be under 6");
            }
            if(userRateArticle.Contains(_actor.Id))
            {
                throw new ArgumentException("You already vote");
            }
            var rate = new Rate
            {
                RateNumber = request.RateNumber,
                UserId = _actor.Id,
                ArticleId = id
            };
            _context.Rates.Add(rate);
            _context.SaveChanges();
        }
    }
}
