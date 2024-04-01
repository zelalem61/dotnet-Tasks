using Application.Common.DTOs.Blog;
using Application.Features.Blogs.Requests.Commands;
using Application.Features.Blogs.Requests.Queries;
using Application.Features.Blogs.Handlers.Queries;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BlogsController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: api/<BlogsController>
        [HttpGet]
        public async Task<ActionResult<List<BlogDTO>>> GetAll()
        {
            var blogs = await _mediator.Send(new GetBlogListRequest());
            return Ok(blogs);
        }

        // GET api/<BlogsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogDTO>> Get(int id)
        {
            var blog = await _mediator.Send(new GetBlogDetailRequest { Id = id });
            return Ok(blog);
        }

        // POST api/<BlogsController>
        [HttpPost]
        [ProducesResponseType(typeof(BaseCommandResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseCommandResponse>> CreateBlog([FromBody] CreateBlogDTO blog)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateBlogCommand { BlogDto = blog };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<BlogsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateBlog(int id, [FromBody] UpdateBlogDTO blog)
        {
            blog.Id = id; // Assuming you want to pass the id in the DTO for updating
            var command = new UpdateBlogCommand { BlogDto = blog };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<BlogsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBlogCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
