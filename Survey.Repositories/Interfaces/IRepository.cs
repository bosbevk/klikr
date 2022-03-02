using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Repositories.Interfaces
{
    internal interface IRepository<T>
    {
        public void Add(T value);
        public void Update(T value);
        public void Delete(Guid id);
        public T Get(Guid id);
        public void Save();
        public IQueryable<T> GetAll();

    }
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> All();
        Task<T> GetById(Guid id);
        Task<bool> Add(T entity);
        Task<bool> Delete(Guid id);
        Task<bool> Update(T entity);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
    }
}
