using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.RequestResponse.Commands;

namespace Book.Core.RequestResponse.Books.Commands.BookShopCategory.Commans.Delete
{
    public class DeleteBookShopCategoryCommand : ICommand
    {
        public required int BookShopId { get; set; }
        public required int Id { get; set; }
    }
}
