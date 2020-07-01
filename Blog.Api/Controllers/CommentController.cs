using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application.Commands.CommentCommands;
using Blog.Application.DataTransfer;
using Blog.Application.Queries.Comment;
using Blog.Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        public CommentController(UseCaseExecutor executor)
        {
            _executor = executor;
        }
        // GET: api/Comment
        [HttpGet]
        public IActionResult Get([FromQuery] CommentSearch search,[FromServices] IGetAllCommentsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET: api/Comment/5
        [HttpGet("{id}", Name = "GetC")]
        public IActionResult Get(int id,[FromServices] IGetCommentQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST: api/Comment
        [HttpPost("article/{id}")]
        public void Post(int id,[FromBody] CommentDto dto,[FromServices] ICreateCommentCommand command)
        {
            _executor.ExecuteCommandComment(command, dto, id);
        }

        // PUT: api/Comment/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CommentDto dto,[FromServices] IUpdateCommentCommand command)
        {
            _executor.ExecuteCommandUpdate(command,dto, id);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteCommentCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
