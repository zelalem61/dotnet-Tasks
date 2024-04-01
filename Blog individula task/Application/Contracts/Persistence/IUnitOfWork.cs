using System;
using System.Threading.Tasks;
using Domain.Entites;

namespace Application.Contracts.Persistence;

public interface IUnitOfWork : IDisposable
{
    IBlogRepository BlogRepository { get; }
    Task Save();
}
