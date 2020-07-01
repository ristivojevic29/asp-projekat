using Blog.Application.Queries.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Searches
{
    public class ArticleSearch:PagedSearch
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        
    }
}
