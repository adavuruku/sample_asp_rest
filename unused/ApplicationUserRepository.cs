using eclinic.api.Data;
using eclinic.api.Entity;
using eclinic.api.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace eclinic.api.Repository
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ApplicationUserRepository> _logger;

        public ApplicationUserRepository(ApplicationDbContext context, ILogger<ApplicationUserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public int Count => throw new NotImplementedException();

        public ApplicationUser Add(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser Add(ApplicationUser entity, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> AddAsync(ApplicationUser entity)
        {
            await _context.ApplicationUsers.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task<ApplicationUser> AddAsync(ApplicationUser entity, string userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> AddRange(IEnumerable<ApplicationUser> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> AddRange(IEnumerable<ApplicationUser> entities, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicationUser>> AddRangeAsync(IEnumerable<ApplicationUser> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicationUser>> AddRangeAsync(IEnumerable<ApplicationUser> entities, string userId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ApplicationUser> All()
        {
            throw new NotImplementedException();
        }

        public IQueryable<ApplicationUser> AllIncluding(params Expression<Func<ApplicationUser, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public bool Contains(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ContainsAsync(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ApplicationUser> FindBy(Expression<Func<ApplicationUser, bool>> predicate) => _context.ApplicationUsers.Where(predicate);

        public ApplicationUser? Get(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ApplicationUser> Get(Expression<Func<ApplicationUser, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> GetAsync(string id)
        {
            return await _context.ApplicationUsers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ApplicationUser?> GetByUserNameAsync(string UserName)
        {
            return await _context.ApplicationUsers.FirstOrDefaultAsync(c => c.UserName == UserName);
        }

        public void Remove(string id)
        {
            throw new NotImplementedException();
        }

        public void Remove(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser Update(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser Update(ApplicationUser entity, string userId)
        {
            throw new NotImplementedException();
        }


    }
}
