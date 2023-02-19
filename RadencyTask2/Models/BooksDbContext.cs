using Microsoft.EntityFrameworkCore;
using RadencyTask2.Models.Books;

namespace RadencyTask2.Models
{
    public class BooksDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Rating> Ratings { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;

        public BooksDbContext(DbContextOptions<BooksDbContext> options)
            : base(options)
        {
        }
    }
}