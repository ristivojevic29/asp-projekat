using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application.Commands.ArticleCommands;
using Blog.Application.DataTransfer;
using Blog.Application.Queries.ArticleQuery;
using Blog.Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        public ArticleController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/Article
        [HttpGet]
        public IActionResult Get(
            [FromQuery] ArticleSearch search,
            [FromServices] IGetAllArticlesQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET: api/Article/5
        [HttpGet("{id}", Name = "GetA")]
        public IActionResult Get(int id,[FromServices] IGetArticleQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST: api/Article
        [HttpPost]
        public IActionResult Post([FromBody] ArticlesDto dto,[FromServices] ICreateArticleCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // PUT: api/Article/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ArticlesDto dto,[FromServices] IUpdateArticleCommand command)
        {
            _executor.ExecuteCommandUpdate(command, dto, id);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteArticleCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
