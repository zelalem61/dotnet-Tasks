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

public class CreateBookCommandHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockUow;
    private readonly CreateBookDTO _bookDto;
    private readonly CreateBookCommandHandler _handler;

    public CreateBookCommandHandlerTests()
    {
        _mockUow = MockUnitOfWork.GetUnitOfWork();
        
        var mapperConfig = new MapperConfiguration(c => 
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _handler = new CreateBookCommandHandler(_mockUow.Object, _mapper);

        _bookDto = new  CreateBookDTO{
             Title = "title",
             Author = "Author Name",
             Genre = "Genre Name",
             ReleaseYear = 2022
        };
    }

    [Fact]
    public async Task Valid_Book_Added()
    {
        var result = await _handler.Handle(new CreateBookCommand() { BookDto = _bookDto }, CancellationToken.None);

        var Books = await _mockUow.Object.BookRepository.GetAll();

        result.ShouldBeOfType<BaseCommandResponse>();

        Books.Count.ShouldBe(5);
    }

    [Fact]
    public async Task InValid_Book_Added()
    {
        _bookDto.Title = "";

        var result = await _handler.Handle(new CreateBookCommand() { BookDto = _bookDto }, CancellationToken.None);

        var Books = await _mockUow.Object.BookRepository.GetAll();
        
        Books.Count.ShouldBe(4);

        result.ShouldBeOfType<BaseCommandResponse>();
        
    }
}
