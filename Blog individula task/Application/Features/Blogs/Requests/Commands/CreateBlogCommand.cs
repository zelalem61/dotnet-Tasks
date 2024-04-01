using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Common.DTOs.Blog;
using Application.Responses;

namespace Application.Features.Blogs.Requests.Commands;

public class CreateBlogCommand : IRequest<BaseCommandResponse>
{
    public CreateBlogDTO BlogDto { get; set; }
}

