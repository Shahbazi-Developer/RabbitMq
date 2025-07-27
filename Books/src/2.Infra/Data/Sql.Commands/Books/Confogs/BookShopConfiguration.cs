using Book.Core.Domain.Books.Entitie;
using Book.SharedKernel.Translators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book.Infra.Data.Sql.Commands.Books.Confogs
{
    public class BookShopConfiguration : IEntityTypeConfiguration<BookShop>
    {
        public void Configure(EntityTypeBuilder<BookShop> builder)

        {
            builder.ToTable("BookShops");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).IsRequired(false).HasMaxLength(MaxLengthConfiguration.GOODS_TITLE_MAXLENGTHS).HasColumnName(nameof(BookShop.Title));

            builder.Property(x => x.Author).IsRequired(false).HasMaxLength(MaxLengthConfiguration.AUTHOR_MAXLENGTHS).HasColumnName(nameof(BookShop.Author));

            builder.Property(x => x.Publisher).IsRequired(false).HasMaxLength(MaxLengthConfiguration.PUBLISHER_MAXLENGTHS).HasColumnName(nameof(BookShop.Publisher));

            builder.Property(x => x.ISBN).IsRequired(false).HasMaxLength(MaxLengthConfiguration.ISBN_MAXLENGTHS).HasColumnName(nameof(BookShop.ISBN));

            builder.Property(x => x.Language).IsRequired(false).HasMaxLength(MaxLengthConfiguration.LANGUAGE_MAXLENGTHS).HasColumnName(nameof(BookShop.Language));

            builder.Property(x => x.Genre).IsRequired(false).HasMaxLength(MaxLengthConfiguration.GENRE_MAXLENGTHS).HasColumnName(nameof(BookShop.Genre));

            builder.Property(x => x.PublicationYear).IsRequired(false).HasMaxLength(MaxLengthConfiguration.PUBLICATION_YEAR__MAXLENGTHS).HasColumnName(nameof(BookShop.PublicationYear));

            builder.Property(x => x.Edition).IsRequired(false).HasMaxLength(MaxLengthConfiguration.EDITION_MAXLENGTHS).HasColumnName(nameof(BookShop.Edition));

            builder.Property(x => x.Price).IsRequired(false).HasMaxLength(MaxLengthConfiguration.PRICE_MAXLENGTHS).HasColumnName(nameof(BookShop.Price));

            builder.Property(x => x.IsAvailable).IsRequired(false).HasColumnName(nameof(BookShop.IsAvailable));

            builder.Property(x => x.StockQuantity).IsRequired(false).HasMaxLength(MaxLengthConfiguration.STOCK_QUANTITY_MAXLENGTHS).HasColumnName(nameof(BookShop.StockQuantity));

            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(MaxLengthConfiguration.DESCRIPTION_REQUEST_MAXLENGTH).HasColumnName(nameof(BookShop.Description));

        }
    }
}
