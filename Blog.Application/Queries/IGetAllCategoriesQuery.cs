using Blog.Application.DataTransfer;
using Blog.Application.Searches;
using Blog.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Queries
{
    public interface IGetAllCategoriesQuery: IQuery<CategorySearch,IEnumerable<CategoryDto>>
    {
    }
}
