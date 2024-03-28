using MediatR;
using System;
using System.Collections.Generic;
using BlogApi.Application.DTOs.PostDto;

namespace BlogApi.Application.Features.Post.Requests.Commands;

public class CreatePostCommand : IRequest<int>
{
    public CreatePostDto createPostDto { get; set; }
}