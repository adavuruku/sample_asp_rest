using eClat.Common.Interfaces;
using eclinic.api.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace eClat.Common.Repository
{
    public abstract class  BaseRepository<TEntity, TId> : IRepository<TEntity, TId>
    where TEntity: class, IEntityBase<TId>
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        private readonly ILogger<ApplicationUserRepository> _logger;

        protected BaseRepository(DbContext context, ILogger<ApplicationUserRepository> logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = _context.Set<TEntity>();

        }

        //non auditable add
        public virtual TEntity Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }


        //auditable add
        public TEntity Add(TEntity entity, string userId)
        {
            SetAuditInfoCreate(entity, userId);
            var entry = _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entry.Entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity, string userId)
        {
            SetAuditInfoCreate(entity, userId);
            var entry = await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }



        // add range non-auditable
        public virtual IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
            _context.SaveChanges();
            return entities;
        }

        public virtual async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return entities;
        }


        //add-range auditable
        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities, string userId)
        {
            foreach (var entity in entities)
            {
                SetAuditInfoCreate(entity, userId);
            }

            _context.Set<TEntity>().AddRange(entities);
            _context.SaveChanges();
            return entities;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, string userId)
        {
            foreach (var entity in entities)
            {
                SetAuditInfoCreate(entity, userId);
            }

            await _context.Set<TEntity>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return entities;
        }

        // update auditable
        public virtual TEntity Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public async virtual Task<TEntity> UpdateAsync(TEntity entity)
        {
             _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async virtual Task<TEntity> UpdateAsync(TEntity entity, string userId)
        {
            SetAuditInfoUpdate(entity, userId);
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }



        public virtual void Remove(TId id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
        }

        public async virtual void RemoveAsync(TId id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public virtual void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public async virtual void RemoveAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }


        // soft delete by entity
        public virtual void SoftRemove(TEntity entity)
        {
            entity.Deleted = true;
            _context.SaveChanges();
        }


        public async virtual void SoftRemoveAsync(TEntity entity)
        {
            entity.Deleted = true;
            await _context.SaveChangesAsync();
        }

        //soft remove by Id

        public virtual void SoftRemove(string id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                SoftRemove(entity);
            }
        }

        public async virtual void SoftRemoveAsync(string id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                SoftRemoveAsync(entity);
            }
        }

        // auditable softDelete by entity
        public virtual void SoftRemove(TEntity entity, string userId)
        {
            SetAuditInfoUpdate(entity, userId);
            SoftRemove(entity);
        }

        public async virtual void SoftRemoveAsync(TEntity entity, string userId)
        {
            SetAuditInfoUpdate(entity, userId);
            SoftRemoveAsync(entity);
        }

        //auditable safe delete by id
        public virtual void SoftRemove(string id, string userId)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                SoftRemove(entity, userId);
            }
        }

        public async virtual void SoftRemoveAsync(string id, string userId)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                SoftRemoveAsync(entity, userId);
            }
        }



        public virtual async Task<bool> ContainsAsync(TId id)
        {
            return await _dbSet.FindAsync(id) != null;
        }

        public virtual async Task<TEntity> GetAsync(TId id)
        {
            return await _dbSet.FindAsync(id);
        }


        

        

        private void SetAuditInfoCreate(TEntity entity, string userId)
        {
            entity.CreatedBy = userId;
            entity.CreateDate = DateTime.UtcNow;
        }

        private void SetAuditInfoUpdate(TEntity entity, string userId)
        {
            entity.UpdatedBy = userId;
            entity.UpdateDate = DateTime.UtcNow;
        }


        public int Count => throw new NotImplementedException();


        public IQueryable<TEntity> All()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public bool Contains(TId id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
           return _context.Set<TEntity>().Where(predicate);
        }

        public TEntity? Get(TId id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity, string userId)
        {
            throw new NotImplementedException();
        }
       
    }
}
