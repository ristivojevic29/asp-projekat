﻿using Blog.Application.Queries.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Searches
{
    public class UserSearch:PagedSearch
    {
        public string Username { get; set; }
    }
}
