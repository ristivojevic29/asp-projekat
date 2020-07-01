using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Commands.ArticleCommands
{
    public interface IDeleteArticleCommand:ICommand<int>
    {
    }
}
