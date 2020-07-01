using Blog.Application;
using Blog.Domain.Entity;
using Blog.EfDataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Logging
{
    public class DatabaseUseCaseLogger : IUseCaseLogger
    {
        private readonly BlogContext _context;
        public DatabaseUseCaseLogger(BlogContext context)
        {
            _context = context;
        }
        public void Log(IUseCase userCase, IApplicationActor actor, object useCaseData)
        {
            var log = new UseCaseLog
            {
                Actor = actor.Identity,
                Data = JsonConvert.SerializeObject(useCaseData),
                Date = DateTime.UtcNow,
                UseCaseName = userCase.Name
            };
            _context.UseCaseLogs.Add(log);
            _context.SaveChanges();
        }
    }
}
