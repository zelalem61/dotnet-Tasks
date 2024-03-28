using Microsoft.EntityFrameworkCore;
using BlogApi.Domain;


namespace BlogApi.Persistence;

public class BlogApi.DbContext : DbContext
{
    public BlogApi.DbContext(DbContextOptions<BlogApi.DbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogApi.DbContext).Assembly);
    }

    protected override Task<int> SaveChangesAsync( CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Created = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModified = DateTime.UtcNow;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<Post> Posts { get; set; };
    public DbSet<Comment> Comments { get; set; };



}
