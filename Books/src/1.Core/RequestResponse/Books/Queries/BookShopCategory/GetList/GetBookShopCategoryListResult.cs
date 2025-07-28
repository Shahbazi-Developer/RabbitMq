using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Core.RequestResponse.Books.Queries.BookShopCategory.GetList
{
    public class GetBookShopCategoryListResult
    {
        public int Id { get; set; }
        public string? CategoryTitle { get; set; }
        public string? Authors { get; set; }
    }
}
