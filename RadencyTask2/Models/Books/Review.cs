using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadencyTask2.Models.Books
{
    public class Review
    {
        [Key]
        public long Id { get; set; }

        public string? Message { get; set; }

        [ForeignKey("Book")]
        public long BookId { get; set; }
        public virtual Book Book { get; set; }

        public string? Reviewer { get; set; }
    }
}