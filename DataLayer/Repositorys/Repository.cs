using CoreLayer.Interfaces.Repository;
using DataLayer.Datas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataLayer.Repositorys
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly InspeccoDB _Context;

        private readonly DbSet<T> _dbset;

        public Repository( InspeccoDB inspeccoDB)
        {
            _Context = inspeccoDB;
            _dbset = _Context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbset.AddAsync(entity);
            return entity;

        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public IQueryable<T> GetAllAsync()
        {
            return _dbset.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
           return _dbset.Where(expression);
        }
    }
}

//using CoreLayer.Interfaces;
//using CoreLayer.Interfaces.Repository;
//using DataLayer.Datas;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataLayer.Repositorys
//{
//    public class Repository<T> : IRepository<T> where T : class
//    {
//        protected readonly InspeccoDB _DB;
//        private readonly DbSet<T> _dbSet;
//        public Repository(InspeccoDB DB)
//        {
//            _DB = DB;
//            _dbSet = _DB.Set<T>();
//        }

//        public async Task AddAsync(T t)
//        {
//           await _dbSet.AddAsync(t);
//        }

//        public async Task AddRangeAsync(IEnumerable<T> entities)
//        {
//            await _dbSet.AddRangeAsync(entities);
//        }

//        public Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
//        {
//            return _dbSet.AnyAsync(expression);
//        }

//        public async Task<T> Find(int id)
//        {
//            return await _dbSet.FindAsync(id);
//        }

//        public IQueryable<T> GetAll()
//        {
//            return _dbSet.AsNoTracking().AsQueryable();
//        }

//        public void Remove(T t)
//        {
//            _dbSet.Remove(t);
//        }

//        public void RemoveRange(IEnumerable<T> entities)
//        {
//            _dbSet.RemoveRange(entities);
//        }

//        public void Update(T t)
//        {
//            _dbSet.Update(t);
//        }

//        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
//        {
//           return _dbSet.Where(expression).AsNoTracking().AsQueryable();
//        }
//    }
//}
