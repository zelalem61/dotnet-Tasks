using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.DTOs.Book;
using Application.Common.DTOs.Book.Validators;
using Application.Common.Exceptions;
using Application.Features.Books.Requests.Commands;
using Application.Contracts.Persistence;
using Application.Responses;
using Domain.Entites;

namespace Application.Features.Books.Handlers.Commands;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateBookCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new UpdateBookDtoValidator();
        var validationResult = await validator.ValidateAsync(request.BookDto);

        if (validationResult.IsValid == false){

            response.Success = false;
            response.Message = "Book Update Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

        }else{

            var book = await _unitOfWork.BookRepository.Get(request.BookDto.Id);
            if (book is null){
                response.Success = false;
                response.Message = "Book Update Failed";
                response.Errors = new List<string>{
                    "Book not found"
                };
            }else{
                _mapper.Map(request.BookDto, book);
                await _unitOfWork.BookRepository.Update(book);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = book.Id;
            }
        }
        return response;
    }
}

