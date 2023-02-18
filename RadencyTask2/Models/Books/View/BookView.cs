using System.ComponentModel.DataAnnotations;

namespace RadencyTask2.Models.Books.View
{
    public class BookView
    {
        [Key]
        public long Id { get; set; }

        public string? Title { get; set; }

        public string? Author { get; set; }

        public decimal? Rating { get; set; }

        public decimal? ReviewsNumber { get; set; }
    }
}