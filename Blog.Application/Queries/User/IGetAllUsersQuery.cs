using Blog.Application.DataTransfer;
using Blog.Application.Queries.Pagination;
using Blog.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Queries.User
{
    public interface IGetAllUsersQuery:IQuery<UserSearch,PagedResponse<UserDto>>
    {
    }
}
