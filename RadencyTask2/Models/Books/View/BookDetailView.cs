using System.ComponentModel.DataAnnotations;

namespace RadencyTask2.Models.Books.View
{
    public class BookDetailView
    {
        [Key]
        public long Id { get; set; }

        public string? Title { get; set; }

        public string? Author { get; set; }

        public string? Cover { get; set; }

        public string? Content { get; set; }

        public decimal? Rating { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}