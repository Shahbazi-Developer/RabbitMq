using Book.Core.Contracts.Books.Queries;
using Book.Core.RequestResponse.Books.Queries.BookShop.GetById;
using Book.Core.RequestResponse.Books.Queries.BookShop.GetList;
using Book.Core.RequestResponse.Books.Queries.BookShop.GetPageFilter;
using Book.Core.RequestResponse.Books.Queries.BookShopCategory.GetList;
using Book.Infra.Data.Sql.Queries.Books.Entities;
using Book.Infra.Data.Sql.Queries.Common;
using Microsoft.EntityFrameworkCore;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Infra.Data.Sql.Queries;
using Zamin.Utilities.Extensions;

namespace Book.Infra.Data.Sql.Queries.Books
{

    #region BookShop
    public class BookShopQueryRepository : BaseQueryRepository<BookQueryDbContext>, IBookShopQueryRepository
    {
        public BookShopQueryRepository(BookQueryDbContext options) : base(options)
        {

        }

        public async Task<GetBookShopByIdResult?> ExecuteAsync(GetBookShopByIdQuery query)
        {
            return await _dbContext.Set<BookShop>().Where(bookShop => bookShop.Id == query.Id && !bookShop.Deleted)
           .Select(bookShop => (GetBookShopByIdResult)bookShop)
           .FirstOrDefaultAsync();
        }


        public async Task<PagedData<GetBookShopPageFilterResult>> ExecuteAsync(GetBookShopPageFilterQuery query)
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


        public async Task<List<GetBookShopListResult>> ExecuteAsync(GetBookShopListQuery query)
        {
            return await _dbContext.Set<BookShop>()
          .Where(x => !x.Deleted)
          .Select(bookShop => (GetBookShopListResult)bookShop)
          .ToListAsync();
        }

        public async Task<List<GetBookShopCategoryListResult>> ExecuteAsync(GetBookShopCategoryListQuery query)
        {
            return await _dbContext.Set<BookShopCategory>().Where(x => !x.Deleted)
              .Select(bookShopCategory => (GetBookShopCategoryListResult)bookShopCategory)
              .ToListAsync();
        }
    }


    #endregion



}
