using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.RequestResponse.Commands;

namespace Book.Core.RequestResponse.Books.BookShopCategory.Commans.Create
{
    public class CreateBookShopCategoryCommand :ICommand
    {
        public int BookShopId { get; set; }
        public string Title { get; set; }
        public string? Authors { get; set; }
    }
}
