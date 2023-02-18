using RadencyTask2.Models.Books;

namespace RadencyTask2.Models.Seeder
{
    public class BookSeed
    {
        public static void AddData(WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetService<BooksDbContext>();

            var books = new List<Book>
                {
                    new Book
                    {
                        Id = 1,
                        Title = "Title1",
                        Cover = "Cover1",
                        Content = "Content1",
                        Author = "Author1",
                        Genre = "Genre1"
                    },
                    new Book
                    {
                        Id = 2,
                        Title = "Title2",
                        Cover = "Cover2",
                        Content = "Content2",
                        Author = "Author2",
                        Genre = "Genre2"
                    },
                    new Book
                    {
                        Id = 3,
                        Title = "Title3",
                        Cover = "Cover3",
                        Content = "Content3",
                        Author = "Author3",
                        Genre = "Genre3"
                    },
                    new Book
                    {
                        Id = 4,
                        Title = "Title4",
                        Cover = "Cover4",
                        Content = "Content4",
                        Author = "Author4",
                        Genre = "Genre4"
                    },
                    new Book
                    {
                        Id = 5,
                        Title = "Title5",
                        Cover = "Cover5",
                        Content = "Content5",
                        Author = "Author5",
                        Genre = "Genre5"
                    },
                    new Book
                    {
                        Id = 6,
                        Title = "Title6",
                        Cover = "Cover6",
                        Content = "Content6",
                        Author = "Author6",
                        Genre = "Genre6"
                    },
                    new Book
                    {
                        Id = 7,
                        Title = "Title7",
                        Cover = "Cover7",
                        Content = "Content7",
                        Author = "Author7",
                        Genre = "Genre7"
                    },
                    new Book
                    {
                        Id = 8,
                        Title = "Title8",
                        Cover = "Cover8",
                        Content = "Content8",
                        Author = "Author8",
                        Genre = "Genre8"
                    },
                    new Book
                    {
                        Id = 9,
                        Title = "Title9",
                        Cover = "Cover9",
                        Content = "Content9",
                        Author = "Author9",
                        Genre = "Genre9"
                    },
                    new Book
                    {
                        Id = 10,
                        Title = "Title10",
                        Cover = "Cover10",
                        Content = "Content10",
                        Author = "Author10",
                        Genre = "Genre10"
                    }
                };
            db.Books.AddRange(books);


            var ratings = new List<Rating> 
            { 
                new Rating
                {
                    Id = 1,
                    BookId = 3,
                    Score = 3
                },
                new Rating
                {
                    Id = 2,
                    BookId = 4,
                    Score = 5
                },
                new Rating
                {
                    Id = 3,
                    BookId = 2,
                    Score = 2
                },
                new Rating
                {
                    Id = 4,
                    BookId = 4,
                    Score = 4
                },
                new Rating
                {
                    Id = 5,
                    BookId = 2,
                    Score = 5
                },
                new Rating
                {
                    Id = 6,
                    BookId = 2,
                    Score = 4
                },
                new Rating
                {
                    Id = 7,
                    BookId = 3,
                    Score = 5
                },
                new Rating
                {
                    Id = 8,
                    BookId = 2,
                    Score = 2
                },
                new Rating
                {
                    Id = 9,
                    BookId = 4,
                    Score = 3
                },
                new Rating
                {
                    Id = 10,
                    BookId = 1,
                    Score = 5
                }
            };
            db.Ratings.AddRange(ratings);

            var reviews = new List<Review>
            {
                new Review
                {
                    Id = 1,
                    Message = "Message1",
                    BookId = 2,
                    Reviewer = "Reviewer1"
                },
                new Review
                {
                    Id = 2,
                    Message = "Message2",
                    BookId = 3,
                    Reviewer = "Reviewer2"
                },
                new Review
                {
                    Id = 3,
                    Message = "Message3",
                    BookId = 1,
                    Reviewer = "Reviewer3"
                },
                new Review
                {
                    Id = 4,
                    Message = "Message4",
                    BookId = 4,
                    Reviewer = "Reviewer4"
                },
                new Review
                {
                    Id = 5,
                    Message = "Message5",
                    BookId = 2,
                    Reviewer = "Reviewer5"
                },
                new Review
                {
                    Id = 6,
                    Message = "Message6",
                    BookId = 5,
                    Reviewer = "Reviewer6"
                },
                new Review
                {
                    Id = 7,
                    Message = "Message7",
                    BookId = 3,
                    Reviewer = "Reviewer7"
                },
                new Review
                {
                    Id = 8,
                    Message = "Message8",
                    BookId = 4,
                    Reviewer = "Reviewer8"
                },
                new Review
                {
                    Id = 9,
                    Message = "Message9",
                    BookId = 1,
                    Reviewer = "Reviewer9"
                },
                new Review
                {
                    Id = 10,
                    Message = "Message10",
                    BookId = 2,
                    Reviewer = "Reviewer10"
                }
            };
            db.Reviews.AddRange(reviews);

            db.SaveChanges();
        }
    }
}