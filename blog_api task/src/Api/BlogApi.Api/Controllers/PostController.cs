using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApi.Core.BlogApi.Domain;
using BlogApi.Core.BlogApi.Application;
using BlogApi.Core.BlogApi.Application.Features.Posts.Features;
using MediatR;


namespace BlogApi.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public PostController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<PostListDto>>> GetPosts()
    {
        return await _mediator.Send(new GetPostsQuery());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PostListDto>> GetPost(Guid id)
    {
        return await _mediator.Send(new GetPostQuery { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<Unit>> CreatePost(CreatePostDto dto)
    {
        return await _mediator.Send(new CreatePostCommand { Post = dto });
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Unit>> UpdatePost(Guid id, UpdatePostDto dto)
    {
        dto.Id = id;
        return await _mediator.Send(new UpdatePostCommand { Post = dto });
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Unit>> DeletePost(Guid id)
    {
        return await _mediator.Send(new DeletePostCommand { Id = id });
    }
}
