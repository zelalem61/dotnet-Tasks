using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

using Application.Common.DTOs.Blog.Validators;
using Application.Common.Exceptions;
using Application.Features.Blogs.Requests.Commands;
using Application.Contracts.Persistence;
using Application.Responses;
using Domain.Entites;

namespace Application.Features.Blogs.Handlers.Commands;

public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand,BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var blog = await _unitOfWork.BlogRepository.Get(request.Id);
        response.Id = request.Id; 
        if (blog == null){
            response.Success = false;
            response.Message = "Blog Update Failed";
            response.Errors = new List<string>{
                "blog not found"
            };
        }else{
            await _unitOfWork.BlogRepository.Delete(blog);
            await _unitOfWork.Save();
            response.Success = true;
            response.Message = "Blog Deleted";   
        }   
        return response;
    }

    // public Task<BaseCommandResponse> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
    // {
    //     throw new NotImplementedException();
    // }

}

