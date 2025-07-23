using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Book.Infra.Data.Sql.Commands.Common;

public class BookCommandDbContextFactory : IDesignTimeDbContextFactory<BookCommandDbContext>
{
    public BookCommandDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<BookCommandDbContext>();

        builder.UseSqlServer("Server =.; Database=BookShopPouyaDB;User Id=sa;Password =1qaz!QAZ;TrustServerCertificate=True;MultipleActiveResultSets=true;Encrypt=false");

        return new BookCommandDbContext(builder.Options);
    }
}