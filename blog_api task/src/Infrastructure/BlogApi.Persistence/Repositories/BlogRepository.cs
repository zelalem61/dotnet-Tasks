using System;
using BlogApi.Application.Persistence.Contracts;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Persistence.Repositories;

public BlogRepository : GenericRepository<Blog>, IBlogRepository
{
    private readonly BlogApi.DbContext _dbContext;
    public BlogRepository(BlogApi.DbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<Blog>> GetAllAsync()
    {
        return await _dbContext.Blogs.Include(b => b.Posts).ToListAsync();
    }
    public async Task<Blog> GetByIdAsync(int id)
    {
        return await _dbContext.Blogs.Include(b => b.Posts).FirstOrDefaultAsync(b => b.Id == id);
    }
    public async Task<Blog> AddAsync(Blog entity)
    {
        await _dbContext.Blogs.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }
    public async Task<Blog> UpdateAsync(Blog entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return entity;
    }
    public async Task<Blog> DeleteAsync(Blog entity)
    {
        _dbContext.Blogs.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

}