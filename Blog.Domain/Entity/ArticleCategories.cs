using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Entity
{
    public class ArticleCategories:Entity
    {
        public int ArticlesId { get; set; }
        public int CategoryId { get; set; }
        public virtual Article Articles { get; set; }
        public virtual Category Categories { get; set; }
    }
}
