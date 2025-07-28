using Book.Core.RequestResponse.Books.Queries.BookShop.GetList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.RequestResponse.Queries;

namespace Book.Core.RequestResponse.Books.Queries.BookShopCategory.GetList
{
    public class GetBookShopCategoryListQuery : IQuery<List<GetBookShopCategoryListResult>>
    {
        public int? BookShopId { get; set; }
    }
}
