using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        public RateController(UseCaseExecutor executor)
        {
            _executor = executor;
        }
        // POST: api/Rate
        [HttpPost("article/{id}")]
        public IActionResult Post(int id,[FromBody] RateDto dto,[FromServices] IRateArticle command)
        {
            _executor.ExecuteCommandComment(command, dto, id);
            return NoContent();
        }

       
    }
}
