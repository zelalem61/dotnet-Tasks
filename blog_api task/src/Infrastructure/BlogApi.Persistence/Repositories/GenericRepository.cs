using System;
using BlogApi.Application.Persistence.Contracts;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BlogApi.Domain;

namespace BlogApi.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly BlogApi.DbContext _dbContext;
    public GenericRepository(BlogApi.DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }
    public async Task<T> DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }
    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }
    public async Task<T> UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return entity;
    }

}
