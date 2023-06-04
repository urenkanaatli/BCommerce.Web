using BCommerce.Application.Data;
using BCommerce.Application.UOWAndRepo;
using BCommerce.Core.DomainClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BCommerce.Insfrastructure.UOWAndRepo
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        protected readonly DbSet<T> _dbSet;
        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }
        public Repository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext.CurentContext;
            _dbSet = _dbContext.Set<T>();
        }

   

        public IList<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public IQueryable<T> GetAll(Func<T, bool> predicate)
        {
            return _dbSet.Where(predicate).AsQueryable();
        }


        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<T> GetAll(Func<T, bool> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query= _dbSet.Where(predicate).AsQueryable();

            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }
    }
}
