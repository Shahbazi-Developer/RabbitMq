using Book.Core.RequestResponse.Books.Queries.BookShopCategory.GetList;
using Zamin.Core.Domain.Entities;
using static Dapper.SqlMapper;

namespace Book.Infra.Data.Sql.Queries.Books.Entities
{
    public class BookShopCategory
    {
        public int Id { get; set; }
        public string? CategoryTitle { get; set; }
        public DateTime CreationDate { get; set; }
        public string? Authors { get; set; }
        public bool Deleted { get; set; }




        public static explicit operator GetBookShopCategoryListResult(BookShopCategory entity) => new()
        {
            Authors = entity.Authors,
            Id = entity.Id,
            CategoryTitle = entity.CategoryTitle
        };
    }


    



}
