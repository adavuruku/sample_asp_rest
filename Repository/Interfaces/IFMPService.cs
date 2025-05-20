using BookStoreApi.Model;

namespace BookStoreApi.Repository.Interfaces
{
    public interface IFMPService
    {
        Task<Stock> FindStockBySymbolAsync(string symbol);
    }
}
