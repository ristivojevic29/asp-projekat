using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Entity
{
    public class Article:Entity
    {
        public string Subject { get; set; }
        public string Text { get; set; }
        public int? PicturesId { get; set; }
        public virtual Pictures Pictures { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ArticleCategories> ArticlesCategories { get; set; } = new HashSet<ArticleCategories>();


        
    }
}
