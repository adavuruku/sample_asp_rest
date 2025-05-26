using BookStoreApi.repository;
using BookStoreApi.Repository.Interfaces;
using System.Threading.Tasks;

namespace BookStoreApi.Services
{
    public class CronJobService
    {
        private readonly IBookRepository _bookRepo;
        private readonly ILogger<CronJobService> _logger;

        public CronJobService(IBookRepository bookRepo, ILogger<CronJobService> logger)
        {
            _bookRepo = bookRepo;
            _logger = logger;
        }

        public async Task RunJob()
        {
            _logger.LogInformation($"Job executed at {DateTime.Now}");
           await  _bookRepo.GetAllAsync();
        }
    }
}
