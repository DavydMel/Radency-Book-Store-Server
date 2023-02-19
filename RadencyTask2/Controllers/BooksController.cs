using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RadencyTask2.Models;
using RadencyTask2.Models.Books;
using RadencyTask2.Models.Books.View;
using System.Text;

namespace RadencyTask2.Controllers
{
    [Route("api")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _cfg;

        public BooksController(BooksDbContext context, IMapper mapper, IConfiguration cfg)
        {
            _context = context;
            _mapper = mapper;
            _cfg = cfg;
        }

        // GET: api/Books
        [Route("books")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookShortView>>> GetBooks()
        {
            string? orderBy = Request.Query["order"];

            List<Book> books;
            if (string.IsNullOrEmpty(orderBy)) 
            {
                books = await _context.Books.Include(b => b.Ratings)
                    .Include(b => b.Reviews).ToListAsync();
            }
            else if (orderBy.ToLower() == "title")
            {
                books = await _context.Books.Include(b => b.Ratings)
                    .Include(b => b.Reviews).OrderBy(b => b.Title).ToListAsync();
            }
            else if (orderBy.ToLower() == "author")
            {
                books = await _context.Books.Include(b => b.Ratings)
                    .Include(b => b.Reviews).OrderBy(b => b.Author).ToListAsync();
            }
            else
            {
                books = await _context.Books.Include(b => b.Ratings).ToListAsync();
            }

            List<BookShortView> bookViews = _mapper.Map<List<BookShortView>>(books);

            return bookViews;
        }

        // GET: api/recommended
        [Route("recommended")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookShortView>>> GetRecommendedBooks()
        {
            string? genre = Request.Query["genre"];
            List<Book> books;

            if(!string.IsNullOrEmpty(genre))
            {
                books = await _context.Books.Include(b => b.Ratings)
                    .Include(b => b.Reviews)
                    .Where(b => b.Genre.ToLower() == genre.ToLower()).ToListAsync();
            }
            else
            {
                books = await _context.Books.Include(b => b.Ratings)
                    .Include(b => b.Reviews).ToListAsync();
            }
            var bookViews = _mapper.Map<List<BookShortView>>(books)
                .OrderByDescending(bv => bv.Rating)
                .Where(bv => bv.ReviewsNumber > 10)
                .Take(10).ToList();
            return bookViews;
        }

        // GET: api/Books/5
        [Route("books/{id}")]
        [HttpGet]
        public async Task<ActionResult<BookDetailView>> GetBook(long id)
        {
            var book = await _context.Books.Include(b => b.Ratings)
                    .Include(b => b.Reviews).FirstOrDefaultAsync(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            BookDetailView bookView = _mapper.Map<BookDetailView>(book);

            return bookView;
        }

        // DELETE: api/Books/5
        [Route("books/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteBook(long id)
        {
            string? secretKeyCfg = _cfg.GetValue<string>("DeleteSecretKey");
            string? secretKey = Request.Query["secret"];

            if (string.IsNullOrEmpty(secretKeyCfg) ||
                string.IsNullOrEmpty(secretKey) ||
                secretKeyCfg != secretKey)
            {
                return BadRequest();
            }
            Console.WriteLine(secretKeyCfg);

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // POST: api/Books/save
        [Route("books/save")]
        [HttpPost]
        public async Task<ActionResult<object>> PostBook(Book book)
        {
            if (!string.IsNullOrEmpty(book.Cover))
            {
                var plainTextBytes = Encoding.UTF8.GetBytes(book.Cover);
                book.Cover = Convert.ToBase64String(plainTextBytes);

                //var base64EncodedBytes = Convert.FromBase64String(book.Cover);
                //Console.WriteLine(Encoding.UTF8.GetString(base64EncodedBytes));
            }

            if (book.Id == 0)
            {
                _context.Books.Add(book);
            }
            else
            {
               _context.Entry(book).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
            return new { Id = book.Id };
        }

        // PUT: api/Books/5/review
        [Route("books/{id}/review")]
        [HttpPut]
        public async Task<ActionResult<object>> PutBookReview(long id, Review review)
        {
            if (!_context.Books.Any(b => b.Id == id))
            {
                return BadRequest();
            }

            review.BookId = id;
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return new { Id = review.Id };
        }

        // PUT: api/Books/5/rate
        [Route("books/{id}/rate")]
        [HttpPut]
        public async Task<ActionResult<object>> PutBookRate(long id, Rating rating)
        {
            if (!_context.Books.Any(b => b.Id == id))
            {
                return BadRequest();
            }

            rating.BookId = id;
            _context.Ratings.Add(rating);
            await _context.SaveChangesAsync();

            return new { Id = rating.Id };
        }
    }
}
