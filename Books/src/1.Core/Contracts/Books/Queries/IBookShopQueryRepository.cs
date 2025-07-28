using Book.Core.RequestResponse.Books.Queries.BookShop.GetById;
using Book.Core.RequestResponse.Books.Queries.BookShop.GetList;
using Book.Core.RequestResponse.Books.Queries.BookShop.GetPageFilter;
using Book.Core.RequestResponse.Books.Queries.BookShopCategory.GetList;
using System.Threading.Tasks;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.Core.RequestResponse.Queries;

namespace Book.Core.Contracts.Books.Queries
{
    public interface IBookShopQueryRepository : IQueryRepository
    {
        #region BookShop
        Task<GetBookShopByIdResult?> ExecuteAsync(GetBookShopByIdQuery query);
        Task<PagedData<GetBookShopPageFilterResult>> ExecuteAsync(GetBookShopPageFilterQuery query);
        Task<List<GetBookShopListResult>> ExecuteAsync(GetBookShopListQuery query);

        #endregion


        #region BookShopCategory
        Task<List<GetBookShopCategoryListResult>> ExecuteAsync(GetBookShopCategoryListQuery query);

        #endregion

    }
}
