using System;
using System.Collections.Generic;
using BlogApi.Domain;
using System.Text;
using System.Threading.Tasks;
namespace BlogApi.Application.Persistence.Contracts{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetAllWithPostAsync();
        Task<Comment> GetByIdWithPostAsync(int id);
    }
}
