using System;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using BlogApi.Application.Features.Post.Requests.Queries;
using BlogApi.Application.DTOs.PostDto;
using BlogApi.Core.Interfaces.Repositories;

namespace BlogApi.Application.Features.Post.Handlers.Queries;

public class GetPostListRequestHandler : IRequestHandler<GetPostListRequest, List<PostDto>>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public GetPostListRequestHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<List<PostDto>> Handle(GetPostListRequest request, CancellationToken cancellationToken)
    {
        var posts = await _postRepository.GetListAsync();
        return _mapper.Map<List<PostDto>>(posts);
    }
}