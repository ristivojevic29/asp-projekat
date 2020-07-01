using Blog.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Commands.CommentCommands
{
    public interface IUpdateCommentCommand:ICommandUpdate<CommentDto,int>
    {
    }
}
