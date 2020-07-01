using Blog.Application;
using Blog.Application.DataTransfer;
using Blog.Application.Queries;
using Blog.Application.Queries.Pagination;
using Blog.Application.Searches;
using Blog.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Blog.Implementation.Queries
{
    public class EfGetLogsQuery : IGetLogsQuery
    {
        private readonly BlogContext _context;
        private readonly IApplicationActor _actor;
        public EfGetLogsQuery(BlogContext context,IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }
        public int Id =>21;

        public string Name => "Get logs by search";

        public PagedResponse<LogDto> Execute(LogSearch search)
        {
            var query = _context.UseCaseLogs.AsQueryable();
            if (!string.IsNullOrEmpty(search.UseCaseName) || !string.IsNullOrWhiteSpace(search.UseCaseName))
            {
                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCaseName.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);
            var response = new PagedResponse<LogDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new LogDto
                {
                  Id=x.Id,
                  Date=x.Date,
                  Data=x.Data,
                  Actor=x.Actor,
                  UseCaseName=x.UseCaseName

                }).ToList()
            };

            return response;
        }
    }
}
