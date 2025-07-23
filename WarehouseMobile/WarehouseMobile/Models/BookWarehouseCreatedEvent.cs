using System.ComponentModel.DataAnnotations;

namespace MobileView.Models
{
    public class BookWarehouseCreatedEvent
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
