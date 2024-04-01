using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Common.DTOs.Blog;
using Application.Responses;

namespace Application.Features.Blogs.Requests.Commands;

public class UpdateBlogCommand : IRequest<BaseCommandResponse>
{
    public UpdateBlogDTO BlogDto { get; set; }
}

