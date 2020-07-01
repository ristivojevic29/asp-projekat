using Blog.Application.DataTransfer;
using Blog.Application.Queries.Pagination;
using Blog.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Queries.ArticleQuery
{
    public interface IGetAllArticlesQuery: IQuery<ArticleSearch, PagedResponse<ArticlesDto>>
    {
    }
}
