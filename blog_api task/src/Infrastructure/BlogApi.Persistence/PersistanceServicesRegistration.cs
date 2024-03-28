using Microsoft.EntityFrameworkCore;
using BlogApi.Application.Persistence.Contracts;
using BlogApi.Domain;
using Microsoft.Extensions.Configuration;
using BlogApi.Persistence.Repositories;

namespace BlogApi.Persistence;

public static class PersistanceServicesRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BlogApi.DbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("BlogApiDbConnection"));
        });
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IBlogRepository, BlogRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        return services;
    }
}
