using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Inventory.Domain;
using Inventory.Domain.Exception;
using Inventory.Domain.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.EntityFramework
{
    public abstract class EfRepositoryBase<T, TKey, TContext> : IRepository<T, TKey>
        where T : class, IEntity<TKey>, new()
        where TKey : IEquatable<TKey>
        where TContext : DbContext, new()
    {
        protected readonly TContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        protected EfRepositoryBase(TContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public virtual T GetById(TKey id)
        {
            try
            {
                return _dbSet.Single(x => x.Id.Equals(id));
            } catch (Exception exception)
            {
                throw new DomainException($"Entity with {id} not found!", exception);
            }
        }

        public virtual async Task<T> GetByIdAsync(TKey id)
        {
            try
            {
                return await _dbSet.SingleAsync(x => x.Id.Equals(id));
            } catch (InvalidOperationException exception)
            {
                throw new DomainException($"Entity with {id} not found!", exception);
            }
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null ? _dbSet.AsNoTracking() : _dbSet.Where(predicate).AsNoTracking();
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> predicate = null, params string[] includes)
        {
            var query = predicate == null ? _dbSet.AsNoTracking() : _dbSet.Where(predicate).AsNoTracking();
            query = ApplyIncludes(query, includes);
            return query;
        }

        public virtual async Task<T> GetByIdAsync(TKey id, params string[] includes)
        {
            var query = _dbSet.AsNoTracking();
            query = ApplyIncludes(query, includes);
            try
            {
                return await query.SingleAsync(x => x.Id.Equals(id));
            } catch (InvalidOperationException exception)
            {
                throw new DomainException($"Entity with {id} not found!", exception);
            }
        }

        public virtual async Task<T> Add(T entity)
        {
            return (await _dbSet.AddAsync(entity)).Entity;
        }

        public virtual T Update(T entity)
        {
            return _dbSet.Update(entity).Entity;
        }

        public virtual T Update(Expression<Func<T, bool>> predicate = null)
        {
            var entity = _dbSet.Find(predicate);
            return entity == null
                ? throw new DomainException($"Entity with {predicate} not found!", new ArgumentNullException())
                : _dbSet.Update(entity).Entity;
        }

        public virtual async Task AddRangeAsync(IEnumerable<T> listEntity)
        {
            await _dbSet.AddRangeAsync(listEntity);
        }

        public virtual T Delete(T entity)
        {
            return _dbSet.Remove(entity).Entity;
        }

        public virtual T Delete(Expression<Func<T, bool>> predicate = null)
        {
            var entity = _dbSet.Find(predicate);
            return entity == null
                ? throw new DomainException($"Entity with {predicate} not found!", new ArgumentNullException())
                : _dbSet.Remove(entity).Entity;
        }

        public virtual Task<int> CountAsync()
        {
            return _dbSet.CountAsync();
        }

        public async Task Dispose()
        {
            await _dbContext.DisposeAsync();
            GC.SuppressFinalize(this);
        }

        private IQueryable<T> ApplyIncludes(IQueryable<T> dbSet, string[] includes) =>
            includes.Where(include => include != string.Empty)
                .Aggregate(dbSet, (current, include) => current.Include(include));
    }
}