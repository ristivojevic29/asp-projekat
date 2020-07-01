using Blog.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Commands.CommentCommands
{
    public interface ICreateCommentCommand:ICommandWithInt<CommentDto,int>
    {
    }
}
