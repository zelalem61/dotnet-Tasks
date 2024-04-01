using AutoMapper;
using Application.Contracts.Persistence;
using Application.Common.DTOs;
using Application.Common.DTOs.Book;

using Application.Features.Books.Handlers.Commands;
using Application.Features.Books.Handlers.Queries;
using Application.Features.Books.Requests.Commands;
using Application.Features.Books.Requests.Queries;
using Application.Responses;

using Application.Profiles;
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

namespace Application.Tests.Books.Queries;

public class DeleteBookRequestHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockUow;
    private readonly  DeleteBookCommandHandler _handler;
    public DeleteBookRequestHandlerTests()
    {
        _mockUow = MockUnitOfWork.GetUnitOfWork();

        var mapperConfig = new MapperConfiguration(c => 
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
       _handler = new DeleteBookCommandHandler(_mockUow.Object, _mapper);
    }

    [Fact]
    public void Valid_DeleteBookTest()
    {
    }

}

