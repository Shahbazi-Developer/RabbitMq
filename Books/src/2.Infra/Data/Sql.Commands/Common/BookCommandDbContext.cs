using Book.Core.Domain.Books.Entitie;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Zamin.Extensions.Events.Outbox.Dal.EF;

namespace Book.Infra.Data.Sql.Commands.Common;

public class BookCommandDbContext : BaseOutboxCommandDbContext
{
    public BookCommandDbContext(DbContextOptions<BookCommandDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }

    public DbSet<BookShop> BookShop { get; set; }
    public DbSet<BookShopCategory> BookShopCategory { get; set; }

}