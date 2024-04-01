using AutoMapper;
using Application.Contracts.Persistence;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Persistence.Repositories;
public class UnitOfWork : IUnitOfWork
{

    private readonly BookMgtDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private IBookRepository _bookRepository;


    public UnitOfWork(BookMgtDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        this._httpContextAccessor = httpContextAccessor;
    }

    public IBookRepository BookRepository => 
        _bookRepository ??= new BookRepository(_context);

    
    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task Save() 
    {
    }
}

