using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(Guid id);
        Task<List<T>> GetAll();
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
