using System;
using System.Collections.Generic;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using BlogApi.Application.Features.Post.Requests.Commands;
using BlogApi.Application.DTOs.PostDto;
using BlogApi.Core.BlogApi.Application.Persistence.Contracts;

namespace BlogApi.Application.Features.Post.Handlers.Commands
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

    public CreatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }
        
        public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePostDtoValidator();
            var validationResult = await validator.ValidateAsync(request.createPostDto);
            if (validationResult.IsValid == false)
                throw new Exceptions.ValidationException(validationResult);
            var post = _mapper.Map<Post>(request.createPostDto);
            await _postRepository.AddAsync(post);
            return post.Id;
        }
    }
}