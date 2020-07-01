using Blog.Application.DataTransfer;
using Blog.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Blog.Application.Commands
{
    public interface IUpdateCategoryCommand:ICommandUpdate<CategoryDto,int>
    {
        
    }
}
