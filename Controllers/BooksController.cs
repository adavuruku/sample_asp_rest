using BookStoreApi.DbConfig;
using BookStoreApi.Dto;
using BookStoreApi.Model;
using BookStoreApi.repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;
        

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
          public async Task<ActionResult<IEnumerable<Book>>> GetBooks() =>
              await _context.Books.ToListAsync();

          [HttpGet("{id}")]
          public async Task<ActionResult<Book>> GetBook(int id)
          {
              var book = await _context.Books.FindAsync(id);
              return book is null ? NotFound() : Ok(book);
          }

          [HttpPost]
          public async Task<ActionResult<Book>> CreateBook(Book book)
          {
              _context.Books.Add(book);
              await _context.SaveChangesAsync();
              return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
          }

          [HttpPut("{id}")]
          public async Task<IActionResult> UpdateBook(int id, Book book)
          {
              if (id != book.Id) return BadRequest();

              _context.Entry(book).State = EntityState.Modified;
              await _context.SaveChangesAsync();

              return NoContent();
          }

          [HttpDelete("{id}")]
          public async Task<IActionResult> DeleteBook(int id)
          {
              var book = await _context.Books.FindAsync(id);
              if (book == null) return NotFound();

              _context.Books.Remove(book);
              await _context.SaveChangesAsync();

              return NoContent();
          }

          [HttpGet("/route")]
          public ActionResult<IEnumerable<Book>> GetBooks([FromQuery] string author)
          {
              if (string.IsNullOrWhiteSpace(author))
              {
                  return BadRequest();
              }

              var filteredBooks = _context.Books.Where(b => b.Author.ToLower().Contains(author.ToLower())).ToList();
              return Ok(filteredBooks);
          }

          [HttpGet("/id/{id}/author/{author}")]
          public ActionResult<IEnumerable<Book>> GetBooksByIdAndAuthor([FromRoute] int id, [FromRoute] string author)
          {
              if (string.IsNullOrWhiteSpace(author))
              {
                  return BadRequest();
              }

              var filteredBooks = _context.Books.Where(b => EF.Functions.ILike(b.Author, $"%{author}%")).ToList();
              return Ok(filteredBooks);
          }

          [HttpGet("/paginate")]
          public async Task<ActionResult<IEnumerable<Book>>> GetBooks([FromQuery] BookQueryDto query)
          {
              var booksQuery = _context.Books.AsQueryable();

              if (!string.IsNullOrWhiteSpace(query.Author))
              {
                  booksQuery = booksQuery.Where(b =>
                      EF.Functions.ILike(b.Author, $"%{query.Author}%"));
              }

              if (!string.IsNullOrWhiteSpace(query.Title))
              {
                  booksQuery = booksQuery.Where(b =>
                      EF.Functions.ILike(b.Title, $"%{query.Title}%"));
              }

              var skip = (query.Page - 1) * query.Size;
              var pagedBooks = await booksQuery
                  .Skip(skip)
                  .Take(query.Size)
                  .ToListAsync();

              return Ok(pagedBooks);
          }

        /**
         * private readonly BookRepository _bookRepo;
                public BooksController(BookRepository bookRepo)
                {
                    //_context = context;
                    _bookRepo = bookRepo;
                }


                
                [HttpGet("by-author")]
                public async Task<IActionResult> GetByAuthor(string author)
                {
                    var books = await _bookRepo.GetByAuthorAsync(author);
                    return Ok(books);
                } **/
    }
}