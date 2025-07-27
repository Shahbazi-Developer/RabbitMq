using Book.Core.RequestResponse.Books.Queries.GetById;
using Book.Core.RequestResponse.Books.Queries.GetList;
using Book.Core.RequestResponse.Books.Queries.GetPageFilter;

namespace Book.Infra.Data.Sql.Queries.BookShops.Entities
{
    public class BookShop
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public string? ISBN { get; set; }
        public string? Language { get; set; }
        public string? Genre { get; set; }
        public int PublicationYear { get; set; }
        public int Edition { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int StockQuantity { get; set; }
        public bool Deleted { get; set; }
        public string? Description { get; set; }





        public static explicit operator GetBookShopByIdResult(BookShop entity) => new()
        {
            Id = entity.Id,
            Author = entity.Author,
            Deleted = entity.Deleted,
            Edition = entity.Edition,
            Genre = entity.Genre,
            IsAvailable = entity.IsAvailable,
            ISBN = entity.ISBN,
            Language = entity.Language,
            Price = entity.Price,
            PublicationYear = entity.PublicationYear,
            Publisher = entity.Publisher,
            StockQuantity = entity.StockQuantity,
            Title = entity.Title,
            Description = entity.Description
            
        };

        public static explicit operator GetBookShopListResult(BookShop entity) => new()
        {
            Id = entity.Id,
            Author = entity.Author,
            Deleted = entity.Deleted,
            Edition = entity.Edition,
            Genre = entity.Genre,
            IsAvailable = entity.IsAvailable,
            ISBN = entity.ISBN,
            Language = entity.Language,
            Price = entity.Price,
            PublicationYear = entity.PublicationYear,
            Publisher = entity.Publisher,
            StockQuantity = entity.StockQuantity,
            Title = entity.Title,
            Description = entity.Description

        };

        public static explicit operator GetBookShopPageFilterResult(BookShop entity) => new()
        {
            Id = entity.Id,
            Author = entity.Author,
            Deleted = entity.Deleted,
            Edition = entity.Edition,
            Genre = entity.Genre,
            IsAvailable = entity.IsAvailable,
            ISBN = entity.ISBN,
            Language = entity.Language,
            Price = entity.Price,
            PublicationYear = entity.PublicationYear,
            Publisher = entity.Publisher,
            StockQuantity = entity.StockQuantity,
            Title = entity.Title,
            Description = entity.Description

        };

    }




}
