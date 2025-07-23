using Book.Core.Contracts.Books.DominService.ArticleGraphServices;
using Book.Core.Domain.Books.Entitie;
using Zamin.Core.Contracts.Data.Commands;

namespace Book.Core.Contracts.Books.Commands
{
    public interface IBookShopCommandRepository : ICommandRepository<BookShop, int>
    {
        Task<BookShop?> GetGraph(BookShopGraphModels model);
    }
}
