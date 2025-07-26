using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.RequestResponse.Commands;

namespace Book.Core.RequestResponse.Books.Commands.BookShopCategory.Commans.Update
{
    public class UpadateBookShopCategoryCommand :ICommand
    {
        public int BookShopCategoryId { get; set; }
        public int BookShopId { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }

    }
}