using Microsoft.EntityFrameworkCore; // Needed for FromSqlRaw and ExecuteSqlRawAsync
using BookStoreApi.DbConfig;
using BookStoreApi.Model;

namespace BookStoreApi.repository
{
    public class BookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
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
