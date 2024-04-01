using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence;

public interface IBlogRepository : IGenericRepository<Blog>
{
}

