using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book.Core.Contracts.Books.Queries;
using Book.Core.RequestResponse.Books.Queries.GetList;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;

namespace Book.Core.ApplicationService.Books.Queries.GetList
{
    public class GetBookShopListHandler : QueryHandler<GetBookShopListQuery, List<GetBookShopListResult>>
    {
        private readonly IBookShopQueryRepository _bookShopQueryRepository;

        public GetBookShopListHandler(ZaminServices zaminServices ,IBookShopQueryRepository bookShopQueryRepository) : base(zaminServices)
        {
            _bookShopQueryRepository = bookShopQueryRepository;
        }

        public override async Task<QueryResult<List<GetBookShopListResult>>> Handle(GetBookShopListQuery query)
        {
            return Result(await _bookShopQueryRepository.GetList(query));
        }
    }
}
