using Application.Contracts.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Mocks;

public static class MockUnitOfWork
{
    public static Mock<IUnitOfWork> GetUnitOfWork()
    {
        var mockUow = new Mock<IUnitOfWork>();
        var mockBookRepo = MockBookRepository.GetBookRepository();

        mockUow.Setup(r => r.BookRepository).Returns(mockBookRepo.Object);

        return mockUow;
    }
}

