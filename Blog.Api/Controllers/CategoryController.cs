using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application;
using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.Application.Queries;
using Blog.Application.Searches;
using Blog.Implementation.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        public CategoryController(UseCaseExecutor executor)
        {
            _executor = executor;
        }
        // GET: api/Category
        [HttpGet]
        public IActionResult Get(
            [FromQuery] CategorySearch search,
            [FromServices] IGetAllCategoriesQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id,[FromServices] IGetCategoryQuery command)
        {
            return Ok(_executor.ExecuteQuery(command, id));
        }

        // POST: api/Category
        [HttpPost]
        public void Post([FromBody] CategoryDto dto,[FromServices]ICreateCategoryCommand command)
        {
            _executor.ExecuteCommand(command, dto);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CategoryDto dto,[FromServices] IUpdateCategoryCommand command)
        {
            _executor.ExecuteCommandUpdate(command, dto, id);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteCategoryCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
