using AutoMapper;
using Application.Contracts.Persistence;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Persistence.Repositories;
public class UnitOfWork : IUnitOfWork
{

    private readonly BlogAPPDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private IBlogRepository _blogRepository;


    public UnitOfWork(BlogAPPDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        this._httpContextAccessor = httpContextAccessor;
    }

    public IBlogRepository BlogRepository => 
        _blogRepository ??= new BlogRepository(_context);

    
    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task Save() 
    {
        // var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;

        // await _context.SaveChangesAsync(username);
    }
}

