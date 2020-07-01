using Blog.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.DataTransfer
{
    public class ArticlesDto
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public int? PicturesId { get; set; }
        public virtual PicturesDto Pictures { get; set; }
        public int? UserId { get; set; }
        public virtual UserDto User { get; set; }
        public ICollection<CategoryDto> Categories { get; set; }
    }
}
