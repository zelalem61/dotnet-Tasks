using AutoMapper;

using MediatR;
using System.Threading;
using System.Threading.Tasks;

using Application.Common.DTOs.Book;
using Application.Common.DTOs.Book.Validators;
using Application.Common.Exceptions;
using Application.Features.Books.Requests.Queries;
using Application.Contracts.Persistence;
using Application.Responses;
using Domain.Entites;

namespace Application.Features.Books.Handlers.Queries;

public class GetBookDetailRequestHandler : IRequestHandler<GetBookDetailRequest, BookDTO>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public GetBookDetailRequestHandler(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }
    public async Task<BookDTO> Handle(GetBookDetailRequest request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.Get(request.Id);
        return _mapper.Map<BookDTO>(book);
    }
}

