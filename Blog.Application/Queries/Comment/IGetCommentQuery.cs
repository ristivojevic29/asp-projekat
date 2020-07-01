﻿using Blog.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Queries.Comment
{
    public interface IGetCommentQuery:IQuery<int,CommentDto>
    {

    }
}
