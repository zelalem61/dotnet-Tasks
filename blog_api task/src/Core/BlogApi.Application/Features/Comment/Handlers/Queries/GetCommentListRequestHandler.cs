using System;
using System.Collections.Generic;
using MediatR;
using BlogApi.Application.DTOs.CommentDto;
using BlogApi.Core.Interfaces.Repositories;


namespace BlogApi.Application.Features.Comment.Handlers.Queries;

public class GetCommentListRequestHandler : IRequestHandler<GetCommentListRequest, List<CommentDto>>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public GetCommentListRequestHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<List<CommentDto>> Handle(GetCommentListRequest request, CancellationToken cancellationToken)
    {
        var comments = await _commentRepository.GetListAsync();
        return _mapper.Map<List<CommentDto>>(comments);
    }
}

