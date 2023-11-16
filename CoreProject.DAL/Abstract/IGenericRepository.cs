using CoreProject.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.DAL.Abstract
{
    public interface IGenericRepository<T>:IRepository<T> where T : class,IEntity,new()
    {
        Task<bool> AddAsync(T model);       
        bool Remove(T model);
        bool Update(T model);

        IQueryable<T> GetWhere(Expression<Func<T, bool>> method);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method);
        Task<T> GetByIdAsync(int id);
    }
}
