using CoreProject.DAL.Abstract;
using CoreProject.DAL.Concrete;
using CoreProject.Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity, new()
    {
        private readonly CoreProjectDbContext _dbContext;

        public GenericRepository(CoreProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<T> Tables => _dbContext.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry=await Tables.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Tables.FindAsync(id);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        {
            var query = Tables.AsQueryable();
            return await query.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        {
            var query = Tables.Where(method);
            return query;
        }

        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry = Tables.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool Update(T model)
        {
            EntityEntry<T> entityEntry =Tables.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
