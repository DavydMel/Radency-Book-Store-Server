using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RadencyTask2.Models;
using RadencyTask2.Models.Books;
using RadencyTask2.Models.Books.View;
using System.Collections.Generic;

namespace RadencyTask2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksDbContext _context;
        private readonly IMapper _mapper;

        public BooksController(BooksDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookView>>> GetBooks()
        {
            string? orderBy = Request.Query["order"];

            List<Book> books = await _context.Books
                .Include(r => r.Reviews).ToListAsync();
            //if (orderBy != null)
            //{
            //    orderBy = orderBy.ToLower();
            //    if(orderBy == "title")
            //    {
            //        books = await _context.Books.OrderBy(x => x.Title).ToListAsync();
            //    }
            //    else if (orderBy == "author")
            //    {
            //        books = await _context.Books.OrderBy(x => x.Author).ToListAsync();
            //    }
            //    else
            //    {
            //        books = await _context.Books.ToListAsync();
            //    }
            //}
            //else
            //{
            //    books = await _context.Books.ToListAsync();
            //}

            List<BookView> bookViews = _mapper.Map<List<BookView>>(books);
            foreach(var bv in bookViews)
            {
                //bv.Rating = CalcAvarageRating(bv.Id);
                bv.ReviewsNumber = CalcReviews(bv.Id);
            }

            //orderBy = orderBy.ToLower();
            //if (orderBy == "author")
            //{
            //    return await _context.Books.OrderBy(x => x.Author).ToListAsync();
            //}
            return bookViews;
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(long id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Bookss/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(long id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetBook", new { id = book.Id }, book);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id },  book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(long id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(long id)
        {
            return _context.Books.Any(e => e.Id == id);
        }

        //private decimal? CalcAvarageRating(long id)
        //{
        //    var rates = _context.Ratings.Where(r => r.BookId == id);

        //    if (rates.Any())
        //    {
        //        decimal generalRating = 0;
        //        foreach (var rate in rates)
        //        {
        //            generalRating += rate.Score;
        //        }
        //        return generalRating / rates.Count();
        //    }
        //    return null;
        //}

        private decimal? CalcReviews(long id)
        {
            return _context.Reviews.Count(r => r.BookId == id);
        }
    }
}
