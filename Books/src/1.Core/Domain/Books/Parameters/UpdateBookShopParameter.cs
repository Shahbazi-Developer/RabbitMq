using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Core.Domain.Books.Parameters
{
    public record UpdateBookShopParameter(string title,
                                          string author,
                                          string publisher,
                                          string iSBN,
                                          string language,
                                          string genre,
                                          int publicationYear,
                                          int edition,
                                          decimal price,
                                          bool isAvailable,
                                          int stockQuantity,
                                          DateTime creationDate);

}
