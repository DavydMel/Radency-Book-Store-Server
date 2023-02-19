using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadencyTask2.Models.Books
{
    public class Rating
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Book")]
        public long BookId { get; set; }
        //public Book Book { get; set; }

        public int Score { get; set; }
    }
}