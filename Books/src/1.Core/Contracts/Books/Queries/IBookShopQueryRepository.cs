using System.Threading.Tasks;
using Book.Core.RequestResponse.Books.Queries.GetById;
using Book.Core.RequestResponse.Books.Queries.GetList;
using Book.Core.RequestResponse.Books.Queries.GetPageFilter;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.Core.RequestResponse.Queries;

namespace Book.Core.Contracts.Books.Queries
{
    public interface IBookShopQueryRepository : IQueryRepository
    {
        Task<GetBookShopByIdResult?> GetBookShopById(GetBookShopByIdQuery query);
        Task<PagedData<GetBookShopPageFilterResult>> GetBookShopPageFilter(GetBookShopPageFilterQuery query);
        Task<List<GetBookShopListResult>> GetList(GetBookShopListQuery query);
    }
}
