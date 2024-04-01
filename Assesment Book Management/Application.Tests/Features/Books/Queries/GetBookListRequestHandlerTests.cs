using AutoMapper;
using Application.Contracts.Persistence;
using Application.Common.DTOs;

using Application.Common.DTOs.Book;
using Application.Features.Books.Handlers.Queries;
using Application.Features.Books.Requests.Queries;
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

public class GetBookListRequestHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IBookRepository> _mockRepo;
    private readonly  GetBookListRequestHandler _handler;
    public GetBookListRequestHandlerTests()
    {
        _mockRepo = MockBookRepository.GetBookRepository();

        var mapperConfig = new MapperConfiguration(c => 
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
       _handler = new GetBookListRequestHandler(_mockRepo.Object, _mapper);

        
    }

    [Fact]
    public async Task GetBookListTest()
    {
        var result = await _handler.Handle(new GetBookListRequest(), CancellationToken.None);
        result.ShouldBeOfType<List<BookDTO>>();
        result.Count.ShouldBe(4);
    }
}

