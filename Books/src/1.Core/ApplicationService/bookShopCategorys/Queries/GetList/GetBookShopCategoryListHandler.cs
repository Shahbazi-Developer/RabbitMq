using Book.Core.Contracts.Books.Queries;
using Book.Core.RequestResponse.Books.Queries.BookShopCategory.GetList;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;

namespace Book.Core.ApplicationService.bookShopCategorys.Queries.GetList
{
    public class GetBookShopCategoryListHandler : QueryHandler<GetBookShopCategoryListQuery, List<GetBookShopCategoryListResult>>
    {
        private readonly IBookShopQueryRepository _bookShopQueryRepository;

        public GetBookShopCategoryListHandler(ZaminServices zaminServices ,IBookShopQueryRepository bookShopQueryRepository) : base(zaminServices)
        {
            _bookShopQueryRepository = bookShopQueryRepository;
        }

        public override async Task<QueryResult<List<GetBookShopCategoryListResult>>> Handle(GetBookShopCategoryListQuery query)
        {
            return Result(await _bookShopQueryRepository.ExecuteAsync(query));
        }
    }
}
