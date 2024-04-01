using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

using Application.Common.DTOs.Blog;
using Application.Responses;
using Domain.Entites;

namespace Application.Features.Blogs.Requests.Queries;

public class GetBlogListRequest : IRequest<List<BlogDTO>>
{
}
