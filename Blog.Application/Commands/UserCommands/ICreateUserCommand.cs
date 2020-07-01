using Blog.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Commands.UserCommands
{
    public interface ICreateUserCommand:ICommand<UserDto>
    {

    }
}
