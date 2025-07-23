using Zamin.Core.RequestResponse.Commands;

namespace Book.Core.RequestResponse.Books.Commands.Create
{
    public class CreateBookShopCommands : ICommand
    {
        public  string Title { get; set; }
        public  string Author { get; set; }
        public  string Publisher { get; set; }
        public  string ISBN { get; set; }
        public  string Language { get; set; }
        public  string Genre { get; set; }
        public  int PublicationYear { get; set; }
        public  int Edition { get; set; }
        public  decimal Price { get; set; }
        public  bool IsAvailable { get; set; }
        public  int StockQuantity { get; set; }
        public  DateTime CreationDate { get; set; }
    }
}
