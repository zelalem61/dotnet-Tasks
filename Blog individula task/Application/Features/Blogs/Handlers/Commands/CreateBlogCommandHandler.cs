using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

using Application.Common.DTOs.Blog.Validators;
using Application.Common.Exceptions;
using Application.Features.Blogs.Requests.Commands;
using Application.Contracts.Persistence;
using Application.Responses;
using Domain.Entites;

namespace Application.Features.Blogs.Handlers.Commands;

public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateBlogCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreateBlogDtoValidator();
        var validationResult = await validator.ValidateAsync(request.BlogDto);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Blog creation Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        else
        {

            var blo = _mapper.Map<Blog>(request.BlogDto);

            blog = await _unitOfWork.BlogRepository.Add(blog);
            await _unitOfWork.Save();
            
            response.Success = true;
            response.Message = "Creation Successfull";
            response.Id = blog.Id;
        }
        return response;
    }

    // public Task<BaseCommandResponse> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    // {
    //     throw new NotImplementedException();
    // }

}

