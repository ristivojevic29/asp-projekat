﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application.Commands.UserCommands;
using Blog.Application.DataTransfer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

        private readonly UseCaseExecutor _executor;
        public RegisterController(UseCaseExecutor executor)
        {
            _executor = executor;
        }
        // POST: api/Register
        [HttpPost]
        public void Post([FromBody] RegisterDto dto,[FromServices] IRegisterUserCommand command)
        {
            _executor.ExecuteCommand(command, dto);
        }

       
    }
}
