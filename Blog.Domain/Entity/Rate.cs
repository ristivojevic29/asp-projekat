using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Entity
{
    public class Rate:Entity
    {
        public int RateNumber { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public int? ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
}
