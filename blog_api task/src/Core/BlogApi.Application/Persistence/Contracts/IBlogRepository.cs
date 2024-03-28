using System;
using BlogApi.Domain;
using System.Collection.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.Persistence.Contracts
{
    public interface IBlogRepository : IGenericRepository<Post>
    {
        Task<IEnumerable<Post>> GetAllWithCommentsAsync();
        Task<Post> GetByIdWithCommentsAsync(int id);
    }
}