using AutoMapper;

using MediatR;
using System.Threading;
using System.Threading.Tasks;

using Application.Common.DTOs.Blog;
using Application.Common.DTOs.Blog.Validators;
using Application.Common.Exceptions;
using Application.Features.Blogs.Requests.Queries;
using Application.Contracts.Persistence;
using Application.Responses;
using Domain.Entites;


namespace Application.Features.Blogs.Handlers.Queries;

public class GetBlogDetailRequestHandler : IRequestHandler<GetBlogDetailRequest, BlogDTO>
{
    private readonly IBlogRepository _blogRepository;
    private readonly IMapper _mapper;

    public GetBlogDetailRequestHandler(IBlogRepository blogRepository, IMapper mapper)
    {
        _blogRepository = blogRepository;
        _mapper = mapper;
    }
    public async Task<BlogDTO> Handle(GetBlogDetailRequest request, CancellationToken cancellationToken)
    {
        var blog = await _blogRepository.Get(request.Id);
        return _mapper.Map<BlogDTO>(blog);
    }
}

