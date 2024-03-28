using System;
using System.Collections.Generic;
using MediatR;
using BlogApi.Application.DTOs.CommentDto;

namespace BlogApi.Application.Features.Comment.Handlers.Commands;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentDto, int> {
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public CreateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateCommentDto request, CancellationToken cancellationToken)
    {
        var validator = new CreateCommentDtoValidator();
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.IsValid == false)
            throw new Exceptions.ValidationException(validationResult);
        var comment = _mapper.Map<Comment>(request);
        await _commentRepository.AddAsync(comment);
        return comment.Id;
    }

}