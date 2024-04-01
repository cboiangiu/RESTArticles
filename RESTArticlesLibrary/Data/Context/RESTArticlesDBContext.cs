using Microsoft.EntityFrameworkCore;

namespace RESTArticlesLibrary.Data.Context;

public class RESTArticlesDBContext : DbContext
{
    public RESTArticlesDBContext(DbContextOptions<RESTArticlesDBContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
