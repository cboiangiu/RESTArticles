using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RESTArticlesLibrary.Data.Context;

public class DesignTimeMigrationContextFactory : IDesignTimeDbContextFactory<RESTArticlesDBContext>
{
    public RESTArticlesDBContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<RESTArticlesDBContext>();
        builder.UseSqlite("Data Source=../RESTArticles/local.db");
        return new RESTArticlesDBContext(builder.Options);
    }
}
