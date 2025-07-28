using Zamin.Core.RequestResponse.Commands;

namespace Book.Core.RequestResponse.Books.Commands.BookShop.Update
{
    public class UpdateBookShopCommands : ICommand
    {
        public required int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string Publisher { get; set; }
        public required string ISBN { get; set; }
        public required string Language { get; set; }
        public required string Genre { get; set; }
        public required int PublicationYear { get; set; }
        public required int Edition { get; set; }
        public required decimal Price { get; set; }
        public required bool IsAvailable { get; set; }
        public required int StockQuantity { get; set; }
        public required DateTime CreationDate { get; set; }
        public required string Description { get; set; }
    }
}
