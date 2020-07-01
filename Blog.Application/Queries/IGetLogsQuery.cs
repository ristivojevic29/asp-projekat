using Blog.Application.DataTransfer;
using Blog.Application.Queries.Pagination;
using Blog.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Queries
{
    public interface IGetLogsQuery:IQuery<LogSearch,PagedResponse<LogDto>>
    {
    }
}
