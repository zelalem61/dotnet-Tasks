using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Responses;

namespace Application.Features.Blogs.Requests.Commands;

public class DeleteBlogCommand : IRequest<BaseCommandResponse>
{
    public int Id { get; set; }
}
