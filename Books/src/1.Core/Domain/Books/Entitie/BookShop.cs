using Book.Core.Domain.Books.Parameters.BookShop.Create;
using Book.Core.Domain.Books.Parameters.BookShop.Update;
using Book.Core.Domain.Books.Parameters.BookShopCategory.Create;
using Book.Core.Domain.Books.Parameters.BookShopCategory.Delete;
using Book.Core.Domain.Books.Parameters.BookShopCategory.Update;
using Zamin.Core.Domain.Entities;
using Zamin.Core.Domain.Exceptions;
using Zamin.Utilities.Resources.Translators;

namespace Book.Core.Domain.Books.Entitie
{
    public class BookShop : AggregateRoot<int>
    {
        public string? Title { get; private set; }
        public string? Author { get; private set; }
        public string? Publisher { get; private set; }
        public string? ISBN { get; private set; }
        public string? Language { get; private set; }
        public string? Genre { get; private set; }
        public int? PublicationYear { get; private set; }
        public int? Edition { get; private set; }
        public decimal? Price { get; private set; }
        public bool? IsAvailable { get; private set; }
        public int? StockQuantity { get; private set; }
        public bool Deleted { get; private set; }
        public DateTime? CreationDate { get; private set; }
        public string? Description { get; private set; }

        private readonly List<BookShopCategory> _bookShopCategory = new List<BookShopCategory>();
        public IReadOnlyList<BookShopCategory> BookShopCategory => _bookShopCategory.AsReadOnly();

        private BookShop()
        {
        }

        public BookShop(CreateBookShopParameter parameter)
        {
            Title = parameter.title;
            Author = parameter.author;
            Publisher = parameter.publisher;
            ISBN = parameter.iSBN;
            Language = parameter.language;
            Genre = parameter.genre;
            PublicationYear = parameter.publicationYear;
            Edition = parameter.edition;
            Price = parameter.price;
            IsAvailable = parameter.isAvailable;
            StockQuantity = parameter.stockQuantity;
            CreationDate = parameter.creationDate;
            Description = parameter.description;


        }

        public void Update(UpdateBookShopParameter parameter)
        {
            Title = parameter.title;
            Author = parameter.author;
            Publisher = parameter.publisher;
            ISBN = parameter.iSBN;
            Language = parameter.language;
            Genre = parameter.genre;
            PublicationYear = parameter.publicationYear;
            Edition = parameter.edition;
            Price = parameter.price;
            IsAvailable = parameter.isAvailable;
            StockQuantity = parameter.stockQuantity;
            CreationDate = parameter.creationDate;
            Description= parameter.description;
            
        }

        public void BookShopDeleted()
        {
            Deleted = true;
        }

        public void CreateBookShopCategory(CreateBookShopCategoryParameter parameter)
        {
            if (parameter == null)
            {
                throw new InvalidEntityStateException(TranslatorKeys.VALIDATION_ERROR_NOT_NULL);
            }

            BookShopCategory bookShopCategory = new(parameter);
            _bookShopCategory.Add(bookShopCategory);
        }

        public void UpdateBookShopCategory(UpdateBookShopCategoryParameter parameter)
        {
            if (parameter == null)
            {
                throw new InvalidEntityStateException(TranslatorKeys.VALIDATION_ERROR_NOT_NULL);
            }

            var entity = _bookShopCategory.First(a => a.Id == parameter.bookShopCategoryId);
            entity.Update(parameter);
        }


        public void DeleteBookShopCategory(DeleteBookShopCategoryParameter parameter)
        {
            var BookShopCategory = _bookShopCategory.First(x => x.Id == parameter.bookShopCategoryId);

            if (BookShopCategory == null)
            {
                throw new InvalidEntityStateException(TranslatorKeys.VALIDATION_ERROR_NOT_EXIST, nameof(parameter.bookShopCategoryId));

            }

            BookShopCategory.Delete();


        }


    };
}