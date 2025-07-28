using Book.Core.Domain.Books.Parameters.BookShopCategory.Create;
using Book.Core.Domain.Books.Parameters.BookShopCategory.Update;
using Book.Core.Domain.Common.ValueObjects.Deleted;
using Zamin.Core.Domain.Entities;

namespace Book.Core.Domain.Books.Entitie
{
    public class BookShopCategory : Entity<int>
    {
        public int BookShopId { get; private set; }
        public string? CategoryTitle { get; private set; }
        public DateTime? CreationDate { get; private set; }
        public string? Authors { get; private set; }
        public Deleted Deleted { get; private set; } = new(false);

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

        public void Delete()
        {
            Deleted = new(true);
        }
    }
}