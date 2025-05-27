using BookStoreApi.DbConfig;
using BookStoreApi.Dto;
using BookStoreApi.KafkaConfig;
using BookStoreApi.Model;
using BookStoreApi.repository;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using static System.Reflection.Metadata.BlobBuilder;
using Microsoft.Extensions.Localization;
using BookStoreApi.Resources;
using BookStoreApi.ExceptionAdvice;

namespace BookStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        // kafka
        private readonly KafkaProducerConfig _kafkaProducerConfig;


    
    // redis
        private readonly RedisService _redisService;

        //locallisation
        private readonly IStringLocalizer<MessageController> _localizer;


        public BooksController(AppDbContext context, KafkaProducerConfig kafkaProducerConfig, RedisService redisService, IStringLocalizer<MessageController> localizer)
        {
            _context = context;
            _kafkaProducerConfig = kafkaProducerConfig;
            _redisService = redisService;
            _localizer = localizer;
        }

        [HttpGet]
          public async Task<ActionResult<IEnumerable<Book>>> GetBooks() =>
              await _context.Books.ToListAsync();

          [HttpGet("{id}")]
          public async Task<ActionResult<Book>> GetBook(int id)
          {
              var book = await _context.Books.FindAsync(id);
              if (book == null){
                // var msg = _localizer["BookNotFound", id];
                var msg = _localizer["MessageFound", id, "Sherif"];
                // throw new NotFoundException(msg);
                throw new NotFoundException(HttpStatus.NotFound, msg);
                // return NotFound(new ProblemDetails
                // {
                //     Title = "Not Found",
                //     Status = 404,
                //     Detail = msg.Value, // ✅ Localized string
                //     Instance = HttpContext.Request.Path
                // });
              }
              throw new NotFoundException(HttpStatus.OK, nameof(book), book);
            //   return Ok(book);
          }

          [HttpPost]
          public async Task<ActionResult<Book>> CreateBook(Book book)
          {
              _context.Books.Add(book);
              await _context.SaveChangesAsync();

            //await _kafkaProducerConfig.ProduceAsync("Transaction.events", JsonSerializer.Serialize(book));

            await _redisService.SetValueAsync("new_book", JsonSerializer.Serialize(book));
            await _redisService.SetHashFieldAsync("new_book_hash", "#bookHash" ,JsonSerializer.Serialize(book));

            // 4. Call your method to set a value with expiration (e.g., 10 minutes)
            await _redisService.SetValueWithExpirationAsync("booky_" + book.Id, JsonSerializer.Serialize(book), TimeSpan.FromMinutes(1));

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