using Blog.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Queries.ArticleQuery
{
    public interface IGetArticleQuery:IQuery<int,ArticlesDto>
    {
    }
}
