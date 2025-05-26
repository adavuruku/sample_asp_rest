using BookStoreApi.DbConfig;
using BookStoreApi.KafkaConfig;
using BookStoreApi.Model;
using BookStoreApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore; // Needed for FromSqlRaw and ExecuteSqlRawAsync

namespace BookStoreApi.repository
{
    public class BookRepository: IBookRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<BookRepository> _logger;

        public BookRepository(AppDbContext context, ILogger<BookRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            _logger.LogInformation("Executing CRON JOB");
            var books = await _context.Books.ToListAsync();

            // Log to console
            foreach (var book in books)
            {
                _logger.LogInformation($"Id: {book.Id}, Book: {book.Title}, Author: {book.Author}");
            }

            return books;
        }

        public async Task<IEnumerable<Book>> GetByAuthorAsync(string author)
        {
            var sql = "SELECT * FROM public.\"Books\" WHERE Author ILIKE {0}";
            return await _context.Books.FromSqlRaw(sql, $"%{author}%").ToListAsync();
        }

        public async Task<int> UpdatePriceAsync(int id, decimal price)
        {
            var sql = "UPDATE public.Books SET Price = {0} WHERE Id = {1}";
            return await _context.Database.ExecuteSqlRawAsync(sql, price, id);
        }
    }
}
