using Application.Contracts.Persistence;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;

public class BlogRepository : GenericRepository<Blog>, IBlogRepository
{
    private readonly BlogAPPDbContext _dbContext;

    public BlogRepository(BlogAPPDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}

