using Blog.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Commands.ArticleCommands
{
    public interface ICreateArticleCommand:ICommandWithPicture<ArticlesDto,PicturesDto>
    {
    }
}
