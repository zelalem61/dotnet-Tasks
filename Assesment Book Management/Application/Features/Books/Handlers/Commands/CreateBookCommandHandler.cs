using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

using Application.Common.DTOs.Book.Validators;
using Application.Common.Exceptions;
using Application.Features.Books.Requests.Commands;
using Application.Contracts.Persistence;
using Application.Responses;
using Domain.Entites;

namespace Application.Features.Books.Handlers.Commands;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateBookCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreateBookDtoValidator();
        var validationResult = await validator.ValidateAsync(request.BookDto);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Book creation Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        else
        {

            var book = _mapper.Map<Book>(request.BookDto);

            book = await _unitOfWork.BookRepository.Add(book);
            await _unitOfWork.Save();
            
            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = book.Id;
        }
        return response;
    }
}

