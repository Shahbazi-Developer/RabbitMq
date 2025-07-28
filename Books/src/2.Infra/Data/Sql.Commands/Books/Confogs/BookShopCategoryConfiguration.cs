using Book.Core.Domain.Books.Entitie;
using Book.SharedKernel.Translators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Infra.Data.Sql.Commands.Books.Confogs
{
    public class BookShopCategoryConfiguration : IEntityTypeConfiguration<BookShopCategory>
    {
        public void Configure(EntityTypeBuilder<BookShopCategory> builder)
        {
            builder.ToTable("BookShopCategorys");
            builder.HasKey(a => a.Id);


            builder.Property(a=>a.CategoryTitle).IsRequired(false).HasMaxLength(MaxLengthConfiguration.GOODS_TITLE_MAXLENGTHS).HasColumnName(nameof(BookShopCategory.CategoryTitle));

            builder.Property(a=>a.Authors).IsRequired(false).HasMaxLength(MaxLengthConfiguration.AUTHOR_MAXLENGTHS).HasColumnName(nameof(BookShopCategory.Authors));


            builder.OwnsOne(p => p.Deleted, builderAction =>
            {
                builderAction.Property(p1 => p1.Value).HasColumnName(nameof(BookShopCategory.Deleted));
            });
        }
    }
}
