using Book.Core.Domain.Books.Parameters.BookShopCategory.Create;
using Book.Core.Domain.Books.Parameters.BookShopCategory.Delete;
using Book.Core.Domain.Books.Parameters.BookShopCategory.Update;
using Book.Core.RequestResponse.Books.Commands.BookShopCategory.Commans.Create;
using Book.Core.RequestResponse.Books.Commands.BookShopCategory.Commans.Delete;
using Book.Core.RequestResponse.Books.Commands.BookShopCategory.Commans.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Core.ApplicationService.Mappers
{
    public static class BookMapper
    {
        public static DeleteBookShopCategoryParameter ToParameter(this DeleteBookShopCategoryCommand command)
        => new DeleteBookShopCategoryParameter(bookShopCategoryId: command.Id,
                                         bookShopId: command.BookShopId);


        public static CreateBookShopCategoryParameter ToParameter(this CreateBookShopCategoryCommand command)
       => new CreateBookShopCategoryParameter(command.Authors,
                                              command.Title);



        public static UpdateBookShopCategoryParameter ToParameter(this UpadateBookShopCategoryCommand command)
       => new UpdateBookShopCategoryParameter(command.BookShopCategoryId,
                                             command.Title,
                                             command.Authors);


    }
}
