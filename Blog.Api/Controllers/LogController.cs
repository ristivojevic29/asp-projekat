using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application.Queries;
using Blog.Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        public LogController(UseCaseExecutor executor)
        {
            _executor = executor;
        }
        // GET: api/Log
        [HttpGet]
        public IActionResult Get([FromQuery] LogSearch search,[FromServices] IGetLogsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query,search));
        }

       

       
        
    }
}
