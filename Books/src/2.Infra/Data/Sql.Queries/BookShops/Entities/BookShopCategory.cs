namespace Book.Infra.Data.Sql.Queries.BookShops.Entities
{
    public class BookShopCategory
    {


        public int Id { get; set; }
        public string CategoryTitle { get; set; }
        public DateTime CreationDate { get; set; }
        public string Authors { get; set; }
    }
}
