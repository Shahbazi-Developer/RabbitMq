using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book.Core.Domain.Books.Entitie;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book.Infra.Data.Sql.Commands.Books.Confogs
{
    public class BookShopConfiguration : IEntityTypeConfiguration<BookShop>
    {
        public void Configure(EntityTypeBuilder<BookShop> builder)
        {
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Author).IsRequired();
            builder.Property(x => x.Publisher).IsRequired();
            builder.Property(x => x.ISBN).IsRequired();
            builder.Property(x => x.Language).IsRequired();
            builder.Property(x => x.Genre).IsRequired();
            builder.Property(x => x.PublicationYear).IsRequired();
            builder.Property(x => x.Edition).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.IsAvailable).IsRequired();
            builder.Property(x => x.StockQuantity).IsRequired();

        }
    }
}
