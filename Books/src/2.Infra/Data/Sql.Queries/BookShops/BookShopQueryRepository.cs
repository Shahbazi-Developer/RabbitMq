using Book.Core.Contracts.Books.Queries;
using Book.Core.RequestResponse.Books.Queries.GetById;
using Book.Core.RequestResponse.Books.Queries.GetList;
using Book.Core.RequestResponse.Books.Queries.GetPageFilter;
using Book.Infra.Data.Sql.Queries.BookShops.Entities;
using Book.Infra.Data.Sql.Queries.Common;
using Microsoft.EntityFrameworkCore;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Infra.Data.Sql.Queries;
using Zamin.Utilities.Extensions;

namespace Book.Infra.Data.Sql.Queries.BookShops
{

    #region BookShop
    public class BookShopQueryRepository : BaseQueryRepository<BookQueryDbContext>, IBookShopQueryRepository
    {
        public BookShopQueryRepository(BookQueryDbContext options) : base(options)
        {

        }

        public async Task<GetBookShopByIdResult?> GetBookShopById(GetBookShopByIdQuery query)
        {
            return await _dbContext.Set<BookShop>().Where(bookShop => bookShop.Id == query.Id && !bookShop.Deleted)
           .Select(bookShop => (GetBookShopByIdResult)bookShop)
           .FirstOrDefaultAsync();
        }


        public async Task<PagedData<GetBookShopPageFilterResult>> GetBookShopPageFilter(GetBookShopPageFilterQuery query)
        {
            var filter = _dbContext.Set<BookShop>()
            .Where(x => !x.Deleted)
            .AsQueryable();


            if (!string.IsNullOrWhiteSpace(query.Title))
            {
                filter = filter.Where(x => x.Title.Contains(query.Title));
            }


            return await filter.ToPagedData(query, bookShop => (GetBookShopPageFilterResult)bookShop);

        }


        public async Task<List<GetBookShopListResult>> GetList(GetBookShopListQuery query)
        {
            return await _dbContext.Set<BookShop>()
          .Where(x => !x.Deleted)
          .Select(bookShop => (GetBookShopListResult)bookShop)
          .ToListAsync();
        }
    }


    #endregion



}
