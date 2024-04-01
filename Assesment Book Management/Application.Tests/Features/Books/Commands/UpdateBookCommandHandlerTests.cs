using AutoMapper;
using Application.Contracts.Persistence;
using Application.Common.DTOs.Book;
using Application.Common.Exceptions;
using Application.Features.Books.Handlers.Commands;
using Application.Features.Books.Handlers.Queries;
using Application.Features.Books.Requests.Commands;
using Application.Features.Books.Requests.Queries;
using Application.Profiles;
using Application.Responses;
using Application.Tests.Mocks;
using Domain;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.Books.Commands;

public class UpdateBookCommandHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockUow;
    private readonly UpdateBookDTO _bookDto;
    private readonly UpdateBookCommandHandler _handler;

    public UpdateBookCommandHandlerTests()
    {
        _mockUow = MockUnitOfWork.GetUnitOfWork();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _handler = new UpdateBookCommandHandler(_mockUow.Object, _mapper);

        _bookDto = new UpdateBookDTO
        {
            Id = 1,
            Title = "title 5",
            Author = "Author Name 5",
            Genre = "Genre Name 5",
            ReleaseYear = 2022
        };
    }

    [Fact]
    public async Task Valid_Book_Updated()
    {
        var result = await _handler.Handle(new UpdateBookCommand() { BookDto = _bookDto }, CancellationToken.None);

        var Books = await _mockUow.Object.BookRepository.GetAll();

        result.ShouldBeOfType<BaseCommandResponse>();
        Books.Count.ShouldBe(4);
        
    }

    [Fact]
    public async Task InValid_Book_Updated()
    {
        _bookDto.Title = ""; 

        var result = await _handler.Handle(new UpdateBookCommand() { BookDto = _bookDto }, CancellationToken.None);

        result.ShouldBeOfType<BaseCommandResponse>();

        var Books = await _mockUow.Object.BookRepository.GetAll();

        Books[1].Title.ShouldNotBe("title 5");
        Books[1].Author.ShouldNotBe("Author Name 5");
    }
}

