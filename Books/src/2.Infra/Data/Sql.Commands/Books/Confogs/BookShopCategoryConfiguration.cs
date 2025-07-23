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
    public class BookShopCategoryConfiguration : IEntityTypeConfiguration<BookShopCategory>
    {
        public void Configure(EntityTypeBuilder<BookShopCategory> builder)
        {
            builder.Property(a=>a.CategoryTitle).IsRequired();
            builder.Property(a=>a.Authors).IsRequired();
        }
    }
}
