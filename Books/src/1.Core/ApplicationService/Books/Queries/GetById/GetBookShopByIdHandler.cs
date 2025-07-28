using Book.Core.Contracts.Books.Queries;
using Book.Core.RequestResponse.Books.Queries.BookShop.GetById;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;

namespace Book.Core.ApplicationService.Books.Queries.GetById
{
    public class GetBookShopByIdHandler : QueryHandler<GetBookShopByIdQuery, GetBookShopByIdResult?>
    {
        private readonly IBookShopQueryRepository _bookShopQueryRepository;

        public GetBookShopByIdHandler(ZaminServices zaminServices, IBookShopQueryRepository bookShopQueryRepository) : base(zaminServices)
        {
            _bookShopQueryRepository = bookShopQueryRepository;
        }

        public override async Task<QueryResult<GetBookShopByIdResult?>> Handle(GetBookShopByIdQuery query)
        {
            return Result(await _bookShopQueryRepository.ExecuteAsync(query));
        }
    }
}
