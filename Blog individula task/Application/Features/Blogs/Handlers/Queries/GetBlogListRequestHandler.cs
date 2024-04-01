using AutoMapper;

using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using Application.Common.DTOs.Blog;
using Application.Common.DTOs.Blog.Validators;
using Application.Common.Exceptions;
using Application.Features.Blogs.Requests.Queries;
using Application.Contracts.Persistence;
using Application.Responses;
using Domain.Entites;

namespace Application.Features.Blogs.Handlers.Queries;

public class GetBlogListRequestHandler : IRequestHandler<GetBlogListRequest, List<BlogDTO>>
{
    private readonly IBlogRepository _blogRepository;
    private readonly IMapper _mapper;

    public GetBlogListRequestHandler(IBlogRepository blogRepository,
            IMapper mapper)
    {
        _blogRepository = blogRepository;
        _mapper = mapper;
    }

    public async Task<List<BlogDTO>> Handle(GetBlogListRequest request, CancellationToken cancellationToken)
    {
        var blogDTOs = new List<BlogDTO>();

        var blogs = await _blogRepository.GetAll();
        blogDTOs = _mapper.Map<List<BlogDTO>>(blogs.ToList());
        return blogDTOs;
    }
}

