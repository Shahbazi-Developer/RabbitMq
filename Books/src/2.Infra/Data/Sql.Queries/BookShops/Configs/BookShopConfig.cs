using Book.Infra.Data.Sql.Queries.BookShops.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book.Infra.Data.Sql.Queries.BookShops.Configs
{
    public class BookShopConfig : IEntityTypeConfiguration<BookShop>
    {
        public void Configure(EntityTypeBuilder<BookShop> builder)
        {
            throw new NotImplementedException();
        }
    }
}
