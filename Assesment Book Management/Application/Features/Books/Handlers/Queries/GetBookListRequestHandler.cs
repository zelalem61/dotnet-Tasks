using AutoMapper;

using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using Application.Common.DTOs.Book;
using Application.Common.DTOs.Book.Validators;
using Application.Common.Exceptions;
using Application.Features.Books.Requests.Queries;
using Application.Contracts.Persistence;
using Application.Responses;
using Domain.Entites;

namespace Application.Features.Books.Handlers.Queries;

public class GetBookListRequestHandler : IRequestHandler<GetBookListRequest, List<BookDTO>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public GetBookListRequestHandler(IBookRepository bookRepository,
            IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }


    public async Task<List<BookDTO>> Handle(GetBookListRequest request, CancellationToken cancellationToken)
    {
        var BookDTOs = new List<BookDTO>();

        var books = await _bookRepository.GetAll();
        BookDTOs = _mapper.Map<List<BookDTO>>(books.ToList());
        return BookDTOs;
    }
}

