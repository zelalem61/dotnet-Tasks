using Application.Contracts.Persistence;
using Domain.Entites;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Mocks;

public static class MockBookRepository
{
    public static Mock<IBookRepository> GetBookRepository()
    {
        var books = new List<Book>{
                new Book
                {
                    Id = 1,
                    Title = "book 1",
                    Author = "Author Name1",
                    Genre = "Genre Name1",
                    ReleaseYear = 2022
                                },
                 new Book
                {
                    Id = 2,
                    Title = "book2",
                    Author = "Author Name2",
                    Genre = "Genre Name2",
                    ReleaseYear = 2023
                                },
                
            };

        var mockRepo = new Mock<IBookRepository>();
        mockRepo.Setup(r => r.GetAll()).ReturnsAsync(books);

        mockRepo.Setup(r => r.Add(It.IsAny<Book>())).ReturnsAsync((Book book) =>
        {
            books.Add(book);
            return book;
        });


        return mockRepo;

    }
}

