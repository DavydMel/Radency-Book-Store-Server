using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using RadencyTask2.Models.Books;
using System;
using System.Reflection.Metadata;

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