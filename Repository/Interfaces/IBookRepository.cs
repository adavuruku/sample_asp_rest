using BookStoreApi.Helpers;
using BookStoreApi.Model;

namespace BookStoreApi.Repository.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();

        Task<IEnumerable<Book>> GetByAuthorAsync(string author);

        Task<int> UpdatePriceAsync(int id, decimal price);
    }
}
