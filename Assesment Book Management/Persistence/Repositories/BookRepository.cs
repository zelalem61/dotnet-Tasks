using Application.Contracts.Persistence;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    private readonly BookMgtDbContext _dbContext;

    public BookRepository(BookMgtDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}

