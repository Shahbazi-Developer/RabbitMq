using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.RequestResponse.Commands;

namespace Book.Core.RequestResponse.Books.Commands.Delete
{
    public class DeleteBookShopCommands : ICommand
    {
        public required int Id { get; set; }
    }
}
