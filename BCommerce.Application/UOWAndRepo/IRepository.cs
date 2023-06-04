using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BCommerce.Application.UOWAndRepo
{
    public interface IRepository<T> where T : class
    {
        T GetById(object id);
        IList<T> GetAll();
        IQueryable<T> GetAll(Func<T, bool> predicate);


        IQueryable<T> GetAll(Func<T, bool> predicate, params Expression<Func<T, object>>[] includes);

        void Add(T entity);

        void Remove(T entity);
    }
}
