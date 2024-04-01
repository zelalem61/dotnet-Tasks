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

namespace Application.Tests.Book.Queries;

public class GetBookRequestHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IBookRepository> _mockRepo;
    private readonly  GetBookDetailRequestHandler _handler;
    public GetBookRequestHandlerTests()
    {
        _mockRepo = MockBookRepository.GetBookRepository();

        var mapperConfig = new MapperConfiguration(c => 
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
       _handler = new GetBookDetailRequestHandler(_mockRepo.Object, _mapper);

        
    }

    [Fact]
    public async Task Valid_GetBookTest()
    {
    }

}

