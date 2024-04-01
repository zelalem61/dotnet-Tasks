using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

using Application.Common.DTOs.Book.Validators;
using Application.Common.Exceptions;
using Application.Features.Books.Requests.Commands;
using Application.Contracts.Persistence;
using Application.Responses;
using Domain.Entites;

namespace Application.Features.Books.Handlers.Commands;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand,BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteBookCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var book = await _unitOfWork.BookRepository.Get(request.Id);
        response.Id = request.Id; 
        if (book == null){
            response.Success = false;
            response.Message = "Book Update Failed";
            response.Errors = new List<string>{
                "Book not found"
            };
        }else{
            await _unitOfWork.BookRepository.Delete(book);
            await _unitOfWork.Save();
            response.Success = true;
            response.Message = "Book Deleted";   
        }   
        return response;
    }
}

