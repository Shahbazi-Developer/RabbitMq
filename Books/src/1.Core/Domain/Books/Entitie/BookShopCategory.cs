using Book.Core.Domain.Books.Parameters.BookShopCategory.Create;
using Book.Core.Domain.Books.Parameters.BookShopCategory.Update;
using Zamin.Core.Domain.Entities;

namespace Book.Core.Domain.Books.Entitie
{
    public class BookShopCategory : Entity<int>
    {
        public string CategoryTitle { get; private set; }
        public DateTime CreationDate { get; private set; }
        public string Authors { get; private set; }
        
        private BookShopCategory()
        {
        }

        public BookShopCategory(CreateBookShopCategoryParameter parameter)
        {
            CategoryTitle = parameter.categoryTitle;
            Authors = parameter.authors;
            CreationDate = DateTime.Now;

        }
        public void Update(UpdateBookShopCategoryParameter parameter)
        {
            CategoryTitle = parameter.categoryTitle;
            Authors = parameter.authors;
        }
    }
}