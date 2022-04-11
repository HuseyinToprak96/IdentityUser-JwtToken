using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Repository
{
   public interface IRepository<T> where T:class
    {
        Task<T> GetByIdAsync(int id);

        Task<T> AddAsync(T entity);
        IQueryable<T> Where(Expression<Func<T,bool>> expression);

        void Update(T entity);

        void Delete(T entity);

        IQueryable<T> GetAllAsync();
    }
}
