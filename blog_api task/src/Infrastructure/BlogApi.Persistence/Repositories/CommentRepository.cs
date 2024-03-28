using System;
using BlogApi.Application.Persistence.Contracts;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BlogApi.Domain;


namespace BlogApi.Persistence.Repositories;

public CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    private readonly BlogApi.DbContext _dbContext;
    public CommentRepository(BlogApi.DbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<Comment>> GetAllAsync()
    {
        return await _dbContext.Comments.Include(c => c.Post).ToListAsync();
    }
    public async Task<Comment> GetByIdAsync(int id)
    {
        return await _dbContext.Comments.Include(c => c.Post).FirstOrDefaultAsync(c => c.Id == id);
    }
    public async Task<Comment> AddAsync(Comment entity)
    {
        await _dbContext.Comments.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }
    public async Task<Comment> UpdateAsync(Comment entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return entity;
    }
    public async Task<Comment> DeleteAsync(Comment entity)
    {
        _dbContext.Comments.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

}