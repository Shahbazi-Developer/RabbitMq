using Book.Core.Contracts.Books.DominService.ArticleGraphServices.Models;

namespace Book.Core.Contracts.Books.DominService.ArticleGraphServices
{
    public class BookShopGraphModels
    {
        public int? BookShopId { get; set; }
        public int BookShopCategoryId { get; set; }

        public BookShopCategoryGraphModel? BookShopCategoryGraphModel { get; set; }

    }
}
