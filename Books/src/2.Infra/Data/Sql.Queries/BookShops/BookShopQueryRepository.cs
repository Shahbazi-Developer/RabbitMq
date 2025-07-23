using Book.Core.Contracts.Books.Queries;
using Book.Core.RequestResponse.Books.Queries.GetById;
using Book.Core.RequestResponse.Books.Queries.GetList;
using Book.Core.RequestResponse.Books.Queries.GetPageFilter;
using Book.Infra.Data.Sql.Queries.Common;
using Microsoft.EntityFrameworkCore;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Infra.Data.Sql.Queries;
using Zamin.Utilities.Extensions;

namespace Book.Infra.Data.Sql.Queries.BookShops
{
    public class BookShopQueryRepository : BaseQueryRepository<BookQueryDbContext>, IBookShopQueryRepository
    {
        public BookShopQueryRepository(BookQueryDbContext options) : base(options)
        {

        }

        public async Task<GetBookShopByIdResult?> GetBookShopById(GetBookShopByIdQuery query)
        {
            return await _dbContext.BookShop.Select(x => new GetBookShopByIdResult
            {
                Id = x.Id,
                Author = x.Author,
                Deleted = x.Deleted,
                Edition = x.Edition,
                Genre = x.Genre,
                IsAvailable = x.IsAvailable,
                ISBN = x.ISBN,
                Language = x.Language,
                Price = x.Price,
                PublicationYear = x.PublicationYear,
                Publisher = x.Publisher,
                StockQuantity = x.StockQuantity,
                Title = x.Title
            }).FirstOrDefaultAsync(x => x.Id == query.Id);
        }


        public async Task<PagedData<GetBookShopPageFilterResult>> GetBookShopPageFilter(GetBookShopPageFilterQuery query)
        {
            var filter = _dbContext.BookShop.Select(x => new GetBookShopPageFilterResult
            {
                Id = x.Id,
                Author = x.Author,
                Deleted = x.Deleted,
                Edition = x.Edition,
                Genre = x.Genre,
                IsAvailable = x.IsAvailable,
                ISBN = x.ISBN,
                Language = x.Language,
                Price = x.Price,
                PublicationYear = x.PublicationYear,
                Publisher = x.Publisher,
                StockQuantity = x.StockQuantity,
                Title = x.Title

            }).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Title))
            {
                filter = filter.Where(x => x.Title.Contains(query.Title));
            }


            return await filter.ToPagedData(query, x => x);
        }


        public async Task<List<GetBookShopListResult>> GetList(GetBookShopListQuery query)
        {
            return await _dbContext.BookShop.Select(x => new GetBookShopListResult
            {
                Id = x.Id,
                Author = x.Author,
                Deleted = x.Deleted,
                Edition = x.Edition,
                Genre = x.Genre,
                IsAvailable = x.IsAvailable,
                ISBN = x.ISBN,
                Language = x.Language,
                Price = x.Price,
                PublicationYear = x.PublicationYear,
                Publisher = x.Publisher,
                StockQuantity = x.StockQuantity,
                Title = x.Title

            }).ToListAsync();
        }
    }
}
