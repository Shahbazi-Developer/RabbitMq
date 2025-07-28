using Zamin.Core.RequestResponse.Queries;

namespace Book.Core.RequestResponse.Books.Queries.BookShop.GetById
{
    public class GetBookShopByIdQuery : IQuery<GetBookShopByIdResult?>
    {
        public int Id { get; set; }
    }
}
