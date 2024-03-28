using System;
using System.Collections.Generic;
using MediatR;
using BlogApi.Application.DTOs.CommentDto;

namespace BlogApi.Application.Features.Comment.Requests.Commands;

public class CreateCommentCommand : IRequest<int>
{
    public CreateCommentDto createCommentDto { get; set; }
}