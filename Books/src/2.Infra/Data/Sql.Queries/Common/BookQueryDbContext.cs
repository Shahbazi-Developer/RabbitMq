using Book.Infra.Data.Sql.Queries.BookShops.Entities;
using Microsoft.EntityFrameworkCore;
using Zamin.Infra.Data.Sql.Queries;

namespace Book.Infra.Data.Sql.Queries.Common;

public class BookQueryDbContext : BaseQueryDbContext
{
    public BookQueryDbContext(DbContextOptions<BookQueryDbContext> options) : base(options)
    {
    }
    public DbSet<BookShop> BookShop { get; set; }
    public DbSet<BookShopCategory> BookShopCategory { get; set; }
}