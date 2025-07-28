using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.RequestResponse.Commands;

namespace Book.Core.RequestResponse.Books.Commands.BookShopCategory.Commans.Create
{
    public class CreateBookShopCategoryCommand :ICommand
    {
        public  required int BookShopId { get; set; }
        public required string Title { get; set; }
        public required string Authors { get; set; }
    }
}
