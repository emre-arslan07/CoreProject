using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.BLL.Abstract
{
    public interface IGenericService<T>
    {
        Task<bool> AddAsync(T model);
        Task<bool> Remove(T model);
        Task<bool> Update(T model);

        IQueryable<T> GetWhere(Expression<Func<T, bool>> method);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method);
        Task<T> GetByIdAsync(int id);
    }
}
