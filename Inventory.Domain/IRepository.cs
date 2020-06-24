using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Inventory.Domain.SharedKernel;

namespace Inventory.Domain
{
    public interface IRepository<T, in TKey> where T : class, IEntity<TKey>, new() where TKey : IEquatable<TKey>
    {
        T GetById(TKey id);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate = null);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate = null, params string[] includes);
        Task<T> GetByIdAsync(TKey id);
        Task<T> GetByIdAsync(TKey id,params string[] includes); 
        Task<T> Add(T entity);
        T Update(T entity);
        T Update(Expression<Func<T, bool>> predicate = null);
        Task AddRangeAsync(IEnumerable<T> listEntity);
        T Delete(T entity);
        T Delete(Expression<Func<T, bool>> predicate = null);
        Task Dispose();
        Task<int> CountAsync();
    }
}