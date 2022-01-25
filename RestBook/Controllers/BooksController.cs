#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestBook.Models;
using System.Data;

namespace RestBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookContext _context;
        public BooksController(BookContext context)
        {
            _context = context;
        }

        // GET: api/Books/GetChicagoCitation/4
        [HttpGet("GetChicagoCitation/{id}")]
        public async Task<ActionResult> GetChicagoCitation(int id)
        {
            var book = await _context.Books.FindAsync(id);

            return Ok(book.AuthorLastName + ", " + book.AuthorFirstName + ". 2022 " + "\"" + book.Title + "\""
                + "\n" + "  Seinfeld: A comedy show research 325, " + "no. 3" + "\n" + "  (February 2022): 316-421." + "\n" + "  https://doi.org/10/xxxx/xxxxxx");
        }

        // GET: api/Books/GetMlaCitation/4
        [HttpGet("GetMlaCitation/{id}")]
        public async Task<ActionResult> GetMlaCitation(int id)
        {
            var book = await _context.Books.FindAsync(id);

            return Ok(book.AuthorLastName + ", " + book.AuthorFirstName + "." + "\"" + book.Title + "\""
                + "\n" + "  Seinfeld: A comedy show" + "," + book.Publisher + ", 2022,pp. 120-126");
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }


        // GET: api/Books/GetSortedBooksAuthorTitleSproc
        [HttpGet("GetSortedBooksAuthorTitleSproc")]
        public ActionResult GetSortedBooksAuthorTitleSproc()
        {
            try
            {
                var books = _context.Books.FromSqlRaw("EXECUTE dbo.GetSortedBooksAuthorTitleSproc");

                return Ok(books);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return Ok("Error");
        }

        // GET: api/Books/GetSortedBooksPublisherAuthorTitleSproc
        [HttpGet("GetSortedBooksPublisherAuthorTitleSproc")]
        public ActionResult GetSortedBooksPublisherAuthorTitleSproc()
        {
            try
            {
                if (!_context.Books.Any())
                    return Ok("No data in db");

                var books = _context.Books.FromSqlRaw("EXECUTE dbo.GetSortedBooksPublisherAuthorTitleSproc");

                return Ok(books);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return Ok("Error");
        }

        // GET: api/Books/GetTotalBooksPrice
        [HttpGet("GetTotalBooksPrice")]
        public async Task<ActionResult> GetTotalBooksPrice()
        {
            try
            {
                if (!_context.Books.Any())
                    return Ok("No data in db");

                var totalPrice = await _context.Books.SumAsync(x => x.Price);

                return Ok(totalPrice);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return Ok("Error");
        }

        // GET: api/Books/GetSortedBooksPublisherAuthorTitle
        [HttpGet("GetSortedBooksPublisherAuthorTitle")]
        public async Task<ActionResult<IEnumerable<Book>>> GetSortedBooksPublisherAuthorTitle()
        {
            try
            {
                if (!_context.Books.Any())
                    return Ok("No data in db");

                var sortedBooks = await _context.Books.OrderBy(x => x.Publisher).ThenBy(x => x.AuthorLastName).ThenBy(x => x.AuthorFirstName).ThenBy(x => x.Title).ToListAsync();

                return sortedBooks;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return Ok("Error");
        }

        // GET: api/Books/GetSortedBooksAuthorTitle
        [HttpGet("GetSortedBooksAuthorTitle")]
        public async Task<ActionResult<IEnumerable<Book>>> GetSortedBooksAuthorTitle()
        {
            try
            {
                if (!_context.Books.Any())
                    return Ok("No data in db");

                var sortedBooks = await _context.Books.OrderBy(x => x.AuthorLastName).ThenBy(x => x.AuthorFirstName).ThenBy(x => x.Title).ToListAsync();

                return sortedBooks;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return Ok("Error");
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            try
            {
                if (!_context.Books.Any())
                    return Ok("No data in db");

                var book = await _context.Books.FindAsync(id);

                return book;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return Ok("Error");
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
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

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
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

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }

    }
}
