using System.ComponentModel.DataAnnotations;

namespace BookApp.Models
{
    public class Book
    {
        [Key]
        public int bookId { get; set; }
        public string bookName { get; set; }
        public string author { get; set; }
        public int price { get; set; }
    }
}
