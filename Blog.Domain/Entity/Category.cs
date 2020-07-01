using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Entity
{
    public class Category:Entity
    {
        public string Name { get; set; }
        public virtual ICollection<ArticleCategories> ArticlesCategories { get; set; } = new HashSet<ArticleCategories>();
    }
}
