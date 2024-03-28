using System;
using System.Collections.Generic;
using MediatR;
using BlogApi.Application.DTOs.PostDto;
namespace BlogApi.Application.Features.Post.Requests.Queries;

public class GetPostListRequest : IRequest<List<PostDto>>{
    

}