using System.ComponentModel.DataAnnotations;

namespace LMSystem.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool IsAvailable { get; set; } = true;
        
        public ICollection<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord>();
    }
}
