using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.DataTransfer
{
    public class RateDto
    {
        public int RateNumber { get; set; }
        public int UserId { get; set; }

        public int ArticleId { get; set; }
    }
}
