using Blog.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.DataTransfer
{
    public class CommentDto
    {
        public string text { get; set; }
        public int UserId { get; set; }
        public virtual UserDto User { get; set; }
        public string Username { get; set; }
        public int ArticleId { get; set; }
    }
}
