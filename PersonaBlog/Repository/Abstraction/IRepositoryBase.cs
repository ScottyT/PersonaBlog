using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PersonaBlog.Repository.Abstraction
{
    public interface IRepositoryBase<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> AllIncluding(Expression<Func<T, object>>[] includeProperties);
        T GetById(string id);
        T GetSingle(Expression<Func<T, bool>> predicate);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
