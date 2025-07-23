using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Core.Contracts.Books
{
    public class WarehouseMobileCreatedEvent
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime CreationDate { get; set; }
    }

}
