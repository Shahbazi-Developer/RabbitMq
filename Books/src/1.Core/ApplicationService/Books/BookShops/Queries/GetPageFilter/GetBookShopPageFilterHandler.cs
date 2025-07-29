using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book.Core.Contracts.Books.Queries;
using Book.Core.RequestResponse.Books.Queries.BookShop.GetPageFilter;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;

namespace Book.Core.ApplicationService.Books.BookShops.Queries.GetPageFilter
{
    public class GetBookShopPageFilterHandler : QueryHandler<GetBookShopPageFilterQuery, PagedData<GetBookShopPageFilterResult>>
    {
        private readonly IBookShopQueryRepository _bookShopQueryRepository;

        public GetBookShopPageFilterHandler(ZaminServices zaminServices ,IBookShopQueryRepository bookShopQueryRepository) : base(zaminServices) 
        {
            _bookShopQueryRepository = bookShopQueryRepository;
        }

        public override async Task<QueryResult<PagedData<GetBookShopPageFilterResult>>> Handle(GetBookShopPageFilterQuery query)
        {
            return Result(await _bookShopQueryRepository.ExecuteAsync(query));
        }
    }
}
