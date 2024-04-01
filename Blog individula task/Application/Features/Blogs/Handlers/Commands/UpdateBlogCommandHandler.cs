using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Application.Common.DTOs.Blog.Validators;
using Application.Common.Exceptions;
using Application.Features.Blogs.Requests.Commands;
using Application.Contracts.Persistence;
using Application.Responses;
using Domain.Entites;

namespace Application.Features.Blogs.Handlers.Commands;

public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateBlogCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new UpdateBlogDtoValidator();
        var validationResult = await validator.ValidateAsync(request.BlogDto);

        if (validationResult.IsValid == false){

            response.Success = false;
            response.Message = "Blog Update Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

        }else{

            var blog = await _unitOfWork.BlogRepository.Get(request.BlogDto.Id);
            if (blog is null){
                response.Success = false;
                response.Message = "Blog Update Failed";
                response.Errors = new List<string>{
                    "Blog not found"
                };
            }else{
                _mapper.Map(request.BlogDto, blog);
                await _unitOfWork.BlogRepository.Update(blog);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = blog.Id;
            }
        }
        return response;
    }
}

